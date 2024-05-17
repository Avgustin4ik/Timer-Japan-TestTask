namespace Code.Core.Views
{
    using Abstract;
    using UniRx;

    public class LapTimeModel : IModel
    {
        public ReactiveProperty<int> Index = new ReactiveProperty<int>();
        public ReactiveProperty<float> Global = new ReactiveProperty<float>();
        public ReactiveProperty<float> Difference = new ReactiveProperty<float>();
    }
}