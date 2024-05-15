namespace Code.Core.Views
{
    using Abstract;
    using UniRx;

    public class StopwatchScreenModel : IModel<StopwatchScreenModel>
    {
        public IReactiveCommand<bool> Run = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> Pause = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> Reset = new ReactiveCommand<bool>();
        public IReactiveCommand<bool> Lap = new ReactiveCommand<bool>();
    }
}