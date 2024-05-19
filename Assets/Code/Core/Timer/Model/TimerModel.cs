namespace Code.Core.Views
{
    using System;
    using Abstract;
    using UniRx;

    public class TimerModel : IModel, ITimer
    {
        public IReactiveProperty<TimeSpan> Time = new ReactiveProperty<TimeSpan>();
        
        public float StartTime;
        public float ElapsedTime;
        public float LastPauseTime;
        public float PauseDuration;
        public bool IsClearStart = true;
        
        private IDisposable _timerRx;
        private IDisposable _alarmRx;
        public ReadOnlyReactiveProperty<bool> IsElapsed { get; set; }
        public IReactiveCommand<bool> IsReset = new ReactiveCommand<bool>();

        public TimerModel()
        {
            IsElapsed = Time.Select(x => x < TimeSpan.Zero && ElapsedTime != 0).ToReadOnlyReactiveProperty();
            _alarmRx = IsElapsed.Select(x=>x==true).Subscribe(_ => Stop());
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
        

        public void Stop()
        {
            _timerRx?.Dispose();
            _alarmRx?.Dispose();
        }

        public void Pause()
        {
            IsClearStart = false;
            LastPauseTime = UnityEngine.Time.time;
            Stop();
        }

        public void Reset()
        {
            ResetValues();
            Stop();
            IsReset.Execute(true);
        }

        public TimeSpan GetCurrentTime() => Time.Value;

        public void Run(TimeSpan time = default)
        {
            if (IsClearStart)
            {
                ResetValues();
                StartTime = UnityEngine.Time.time;
                ElapsedTime = (float)time.TotalSeconds;
            }
            else
                PauseDuration += UnityEngine.Time.time - LastPauseTime;
            
            _timerRx = Observable.EveryUpdate().Subscribe(_ =>
            {
                Time.Value = TimeSpan.FromSeconds(ElapsedTime - (UnityEngine.Time.time - StartTime - PauseDuration));
            });
        }
        
    }
}