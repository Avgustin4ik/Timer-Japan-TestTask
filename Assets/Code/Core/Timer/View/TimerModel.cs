namespace Code.Core.Views
{
    using System;
    using Abstract;
    using UniRx;

    public class TimerModel : IModel
    {
        public IReactiveProperty<TimeSpan> Time = new ReactiveProperty<TimeSpan>();
        public IReactiveCommand<bool> Reset = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> Pause = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> Run = new ReactiveCommand<bool>();
        
        public float StartTime;
        public float ElapsedTime;
        public float LastPauseTime;
        public float PauseDuration;
        public bool IsClearStart = true;

        public void ResetValues()
        {
            Time.Value = TimeSpan.Zero;
            StartTime = 0;
            ElapsedTime = 0;
            LastPauseTime = 0;
            PauseDuration = 0;
            IsClearStart = true;
        }
    }
}