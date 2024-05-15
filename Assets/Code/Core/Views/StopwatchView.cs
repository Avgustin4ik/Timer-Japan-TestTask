namespace Code.Core.Views
{
    using System;
    using Abstract;
    using Models;
    using TMPro;
    using UniRx;
    using UnityEngine;

    public class StopwatchView : UiView<StopwatchModel>
    {
        [SerializeField] private TextMeshProUGUI timeText;
        // [SerializeField] private StopwatchLapView lapView;
        //todo: запуск таймера
        //todo: отображение таймера в формате hh:mm:ss
        //todo: пауза таймера
        //todo: возобновление таймера
        //todo: сброс таймера
        protected override void Initialize(StopwatchModel model)
        {
            model.Time.Subscribe(currentTimeSpan => SetTime(currentTimeSpan - model.StartTime)).AddTo(this);
            model.Run.Subscribe(_ => model.StartTime = DateTime.Now.TimeOfDay).AddTo(this);
            model.Pause.Subscribe(_ => model.Time.Value = DateTime.Now.TimeOfDay - model.StartTime).AddTo(this);
            // model.Reset.Subscribe(_ => model.Time.Value = TimeSpan.Zero).AddTo(this);
            // model.Lap.Subscribe(_ => model.Laps.Add(DateTime.Now.TimeOfDay - model.StartTime)).AddTo(this);
            
            base.Initialize(model);
        }
        
        private void SetTime(TimeSpan time)
        {
            timeText.text = time.ToString(@"hh\:mm\:ss");
        }
    }
}