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
        
        private IDisposable _timerRx;

        public void Run()
        {
            if(IsClearStart)
                StartTime = UnityEngine.Time.time;
            else
                PauseDuration += UnityEngine.Time.time - LastPauseTime;
            _timerRx = Observable.EveryUpdate().Subscribe(_ =>
            {
                var time = UnityEngine.Time.time - StartTime - PauseDuration;
                Time.Value = TimeSpan.FromSeconds(time);
            });
        }
        
        public void Pause()
        {
            IsClearStart = false;
            LastPauseTime = UnityEngine.Time.time;
            Stop();
        }
        
        public void Stop()
        {
            _timerRx.Dispose();
        }
        
        public void Lap()
        {
            Laps.Add(new LapTime
            {
                Index = Laps.Count + 1,
                Global = Time.Value.TotalSeconds,
                Difference = Laps.Count > 0 ? Time.Value.TotalSeconds - Laps[^1].Global : 0f
            });
        }
    }
}