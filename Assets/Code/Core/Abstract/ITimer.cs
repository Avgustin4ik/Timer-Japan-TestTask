namespace Code.Core
{
    using System;

    public interface ITimer : IControl
    {
        public virtual TimeSpan GetCurrentTime() => TimeSpan.Zero;
        public abstract void Run(TimeSpan time);
    }
}