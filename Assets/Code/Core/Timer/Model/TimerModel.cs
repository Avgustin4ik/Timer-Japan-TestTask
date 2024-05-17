namespace Code.Core.Timer.Model
{
    using System;
    using Code.Core.Abstract;
    using UniRx;

    public class TimerModel : IModel
    {
        public IReactiveProperty<TimeSpan> Time = new ReactiveProperty<TimeSpan>();
        
        public IReactiveCommand<bool> Run = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> Pause = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> Reset = new ReactiveCommand<bool>();
        // public bool IsClearStart { get; set; }
    }
}