namespace Code.Core.Models
{
    using System;
    using Code.Core.Abstract;
    using UniRx;

    public class ClockModel : IModel
    {
        public IReactiveProperty<TimeSpan> Time = new ReactiveProperty<TimeSpan>();
    }
}