namespace Code.Core.Views
{
    using System.Collections.Generic;
    using Abstract;
    using Zenject;

    public class SetterTimerView : UiView<SetterTimerModel>
    {
        public ScrollMechanic hours;
        public ScrollMechanic minutes;
        public ScrollMechanic seconds;
        
        [Inject]
        protected override void Initialize(SetterTimerModel model)
        {
            hours.Initialize(LoadSymbols(24));
            minutes.Initialize(LoadSymbols(60));
            seconds.Initialize(LoadSymbols(60));
            base.Initialize(model);
        }

        private List<string> LoadSymbols(int count)
        {
            List<string> symbols = new List<string>();
            for (int i = 0; i < count; i++)
            {
                symbols.Add(i.ToString("00"));
            }
            return symbols;
        }
    }
}