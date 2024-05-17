namespace Code.Core.Views
{
    using System;
    using Abstract;
    using UniRx;

    public class SetterTimerModel : IModel
    {
        public IReactiveCommand<TimeSpan> Start = new ReactiveCommand<TimeSpan>();
        public IReactiveCommand<bool> Cancel = new ReactiveCommand<bool>();
    }
}