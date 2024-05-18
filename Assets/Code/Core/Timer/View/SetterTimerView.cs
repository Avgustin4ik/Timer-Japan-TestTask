namespace Code.Core.Views
{
    using System;
    using System.Collections.Generic;
    using Abstract;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    public class SetterTimerView : UiView<SetterTimerModel>
    {
        public ScrollMechanic hours;
        public ScrollMechanic minutes;
        public ScrollMechanic seconds;
        [SerializeField] private Button startButton;
        [SerializeField] private Button cancelButton;
        protected override void Initialize(SetterTimerModel model)
        {
            hours.Initialize(LoadSymbols(24));
            minutes.Initialize(LoadSymbols(60));
            seconds.Initialize(LoadSymbols(60));
            
            startButton.onClick.AddListener(() => Model.Start.Execute(GetTimeSpan()));
            cancelButton.onClick.AddListener(() => Model.Cancel.Execute(true));
            base.Initialize(model);
        }

        private TimeSpan GetTimeSpan()
        {
            return new TimeSpan(hours.GetCurrentValue(), minutes.GetCurrentValue(), seconds.GetCurrentValue());
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