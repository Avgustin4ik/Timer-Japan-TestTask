namespace Code.Core.Views
{
    using System;
    using Abstract;
    using TMPro;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    public class TimerView : UiView<TimerModel>
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private Button startButton;
        [SerializeField] private Button resetButton;
        [SerializeField] private Button pauseButton;
        private IDisposable _timerRx;
        [Inject]
        protected override void Initialize(TimerModel model)
        {
            model.Time.Subscribe(x=>DisplayTime(x)).AddTo(this);
            model.Run.Subscribe(_ => { Run(); pauseButton.gameObject.SetActive(true); startButton.gameObject.SetActive(false);}).AddTo(this);
            model.Pause.Subscribe(_ => { Pause(); pauseButton.gameObject.SetActive(false); startButton.gameObject.SetActive(true); }).AddTo(this);
            model.Reset.Subscribe(_ => Reset()).AddTo(this);
            base.Initialize(model);
        }

        private void Reset()
        {
            Model.ResetValues();
            Stop();
        }

        private void Pause()
        {
            Model.IsClearStart = false;
            Model.LastPauseTime = Time.time;
            Stop();
        }
        
        
        private void Stop()
        {
            _timerRx.Dispose();
        }


        private void DisplayTime(TimeSpan timeSpan)
        {
            timeText.text = timeSpan.ToString(@"hh\:mm\:ss");
        }

        public void Run()
        {
            if (Model.IsClearStart)
                Model.StartTime = Time.time;
            else
                Model.PauseDuration += Time.time - Model.LastPauseTime;
            
            _timerRx = Observable.Interval(TimeSpan.FromMilliseconds(1)).Subscribe(_ =>
            {
                Model.Time.Value = TimeSpan.FromSeconds(Model.ElapsedTime - (Time.time -Model.StartTime - Model.PauseDuration));
            });
        }
    }
}