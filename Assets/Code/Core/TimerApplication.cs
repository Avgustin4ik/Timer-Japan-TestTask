namespace Code.Core
{
    using Zenject;

    public class TimerApplication : ITimerApplication
    {
        [Inject] public ITimer Timer { get; private set; }
        [Inject] public IStopwatch Stopwatch { get; private set; }
        [Inject] public IClock Clock { get; private set; }
    }


    public interface ITimerApplication
    {
        
    }
}