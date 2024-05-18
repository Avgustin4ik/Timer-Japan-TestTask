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
        
        public ReadOnlyReactiveProperty<bool> IsElapsed { get; set; }

        private TimerModel()
        {
            IsElapsed = Time.Select(x => x < TimeSpan.Zero && ElapsedTime != 0).ToReadOnlyReactiveProperty();
        }
        
        public void ResetValues()
        {
            Time.Value = TimeSpan.Zero;
            StartTime = default;
            ElapsedTime = default;
            LastPauseTime = default;
            PauseDuration = default;
            IsClearStart = true;
        }
    }
}