namespace Code.Core
{
    using Zenject;

    public class TimerApplicationAPI : ITimerApplication
    {
        [Inject] public ITimer Timer;
        [Inject] public IStopwatch Stopwatch;
        [Inject] public IClock Clock;
    }
}