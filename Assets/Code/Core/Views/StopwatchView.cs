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
        
        private IDisposable _timerRx;
        
        [Inject]
        protected override void Initialize(StopwatchModel model)
        {
            model.Time.Subscribe(x=>DisplayTime(x)).AddTo(this);
            model.Run.Subscribe(_=>Run()).AddTo(this);
            model.Pause.Subscribe(_ =>Pause()).AddTo(this);
            model.Reset.Subscribe(_ => Reset()).AddTo(this);
            model.Lap.Subscribe(_ => Lap()).AddTo(this);
            
            base.Initialize(model);
        }

        private void Lap()
        {
            throw new NotImplementedException("LapStopwatch not implemented yet!");
            Model.Laps.Add(new LapTime
            {
                Global = Time.time - Model.StartTime,
                Difference = Time.time - Model.StartTime - Model.PauseDuration
            });
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
    }
}