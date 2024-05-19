namespace Code.Core.Models
{
    using System;
    using Code.Core.Abstract;
    using UniRx;

    public class StopwatchModel : IModel
    {
        public IReactiveProperty<TimeSpan> Time = new ReactiveProperty<TimeSpan>();
        public IReactiveCollection<LapTime> Laps = new ReactiveCollection<LapTime>();

        public float StartTime;
        public float LastPauseTime;
        public float PauseDuration;
        public bool IsClearStart = true;

        public void ResetValues()
        {
            Time.Value = TimeSpan.Zero;
            StartTime = 0;
            LastPauseTime = 0;
            PauseDuration = 0;
            IsClearStart = true;
            Laps.Clear();
        }
    }
}