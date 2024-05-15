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
        // [SerializeField] private StopwatchLapView lapView;
        //todo: запуск таймера
        //todo: отображение таймера в формате hh:mm:ss
        //todo: пауза таймера
        //todo: возобновление таймера
        //todo: сброс таймера
        
        private IDisposable _timerRx;
        [Inject]
        protected override void Initialize(StopwatchModel model)
        {
            model.Time.Subscribe(x=>DisplayTime(x)).AddTo(this);
            model.Run.Subscribe(_=>Run()).AddTo(this);
            model.Pause.Subscribe(_ =>Pause()).AddTo(this);
            model.Reset.Subscribe(_ => Reset()).AddTo(this);
            // model.Lap.Subscribe(_ => model.Laps.Add(DateTime.Now.TimeOfDay - model.StartTime)).AddTo(this);
            
            base.Initialize(model);
        }

        private void Pause()
        {
            Stop();
            
        }

        private void Reset()
        {
            Stop();
            Model.Time.Value = TimeSpan.Zero;
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
            Model.StartTime = Time.time;
            _timerRx = Observable.EveryUpdate().Subscribe(_ =>
            {
                var time = Time.time - Model.StartTime;
                Model.Time.Value = TimeSpan.FromSeconds(time);
            });
        }
    }
}