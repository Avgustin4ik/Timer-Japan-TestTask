namespace Code.Core.Views
{
    using System;
    using Abstract;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    public class TimerScreenView : UiView<TimerScreenModel>
    {
        [SerializeField] private Button setTimerButton;
        [SerializeField] private SetterTimerView setter;
        // [SerializeField] private TimerView timer;
        [Inject]
        protected override void Initialize(TimerScreenModel model)
        {
            setter.Display(false);
            setTimerButton.gameObject.SetActive(true);
            
            setTimerButton.onClick.AddListener(() => ShowSetter());

            setter.Model.Start.Subscribe(StartTimer).AddTo(this);
            setter.Model.Cancel.Subscribe(_ =>Cancel()).AddTo(this);
            base.Initialize(model);
        }

        private void ShowSetter()
        {
            setter.Display(true);
            setTimerButton.gameObject.SetActive(false);
        }

        private void Cancel()
        {
            setter.Display(false);
            setTimerButton.gameObject.SetActive(true);
        }

        private void StartTimer(TimeSpan timeSpan)
        {
            setter.Display(false);
            throw new NotImplementedException();
        }
    }

    public class TimerScreenModel : IModel
    {
        
    }
}