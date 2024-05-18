namespace Code.Core.Views
{
    using System;
    using Abstract;
    using Models;
    using TMPro;
    using UniRx;
    using UnityEngine;
    using Zenject;

    public class StopwatchView : UiView<StopwatchModel>
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private LapTimeView lapView;
        [SerializeField] private RectTransform lapsContainer;
        private IDisposable _timerRx;
        [Inject] private LapTimeView.Factory _lapTimeViewFactory;
        
        [Inject]
        protected override void Initialize(StopwatchModel model)
        {
            model.Time.Subscribe(x=>DisplayTime(x)).AddTo(this);
            model.Run.Subscribe(_=>Run()).AddTo(this);
            model.Pause.Subscribe(_ =>Pause()).AddTo(this);
            model.Reset.Subscribe(_ => Reset()).AddTo(this);
            model.Lap.Subscribe(_ => Lap()).AddTo(this);
            
            model.Laps.ObserveAdd().Subscribe(x =>
            {
                var lapTimeView = _lapTimeViewFactory.Create();
                lapTimeView.transform.SetParent(lapsContainer);
                lapTimeView.transform.localScale = Vector3.one;
                lapTimeView.transform.position = Vector3.zero;
                lapTimeView.Model.LapTime.Value = x.Value;
            }).AddTo(this);
            
            model.Laps.ObserveReset().Subscribe(x => KillAllLaps()).AddTo(this);
            base.Initialize(model);
        }

        private void KillAllLaps()
        {
            foreach (Transform child in lapsContainer)
            {
                Destroy(child.gameObject);
            }
        }


        private void Pause()
        {
            Model.IsClearStart = false;
            Model.LastPauseTime = Time.time;
            Stop();
        }

        private void Reset()
        {
            Model.ResetValues();
            Stop();
        }

        private void Stop()
        {
            _timerRx.Dispose();
        }

        private void DisplayTime(TimeSpan timeSpan)
        {
            timeText.text = timeSpan.ToString(@"hh\:mm\:ss\,fff");
        }

        private void Run()
        {
            //todo move to model
            if(Model.IsClearStart)
                Model.StartTime = Time.time;
            else
                Model.PauseDuration += Time.time - Model.LastPauseTime;
            _timerRx = Observable.EveryUpdate().Subscribe(_ =>
            {
                var time = Time.time - Model.StartTime - Model.PauseDuration;
                Model.Time.Value = TimeSpan.FromSeconds(time);
            });
        }
        public void Lap()
        {
            Model.Laps.Add(new LapTime
            {
                Index = Model.Laps.Count + 1,
                Global = (float)Model.Time.Value.TotalSeconds,
                Difference = Model.Laps.Count > 1 ? Time.time - Model.Laps[^1].Global : 0f
            });
        }
    }
}
