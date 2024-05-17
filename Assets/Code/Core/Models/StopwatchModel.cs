namespace Code.Core.Models
{
    using System;
    using System.Collections.Generic;
    using Code.Core.Abstract;
    using UniRx;

    public class StopwatchModel : IModel
    {
        public IReactiveProperty<TimeSpan> Time = new ReactiveProperty<TimeSpan>();
        
        public IReactiveCommand<bool> Run = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> Pause = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> Reset = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> Lap = new ReactiveCommand<bool>();
        
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

    [Serializable]
    public struct LapTime
    {
        public float Global;
        public float Difference;
    }
}