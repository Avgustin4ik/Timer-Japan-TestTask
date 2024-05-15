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
        
        private List<TimeSpan> _laps = new List<TimeSpan>();
        public IReadOnlyList<TimeSpan> Laps => _laps;
        public float StartTime;
    }
}