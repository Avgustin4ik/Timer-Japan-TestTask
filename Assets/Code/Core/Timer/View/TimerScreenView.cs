namespace Code.Core.Views
{
    using System;
    using Abstract;
    using Panel.View;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    public class TimerScreenView : ScreenView
    {
        [SerializeField] private Button setTimerButton;
        [SerializeField] private SetterTimerView setter;
        [SerializeField] private TimerView timer;

        protected override void Initialize(ScreenModel model)
        {
            InitialState();
            
            setTimerButton.onClick.AddListener(() => ShowSetter());
        
            setter.Model.Start.Subscribe(x =>
            {
                if (x!=TimeSpan.Zero)
                    StartTimer(x);
            }).
            AddTo(this);
            
            setter.Model.Cancel.Subscribe(_ =>Cancel()).AddTo(this);
            timer.Model.Reset.Subscribe(_ => InitialState()).AddTo(this);
        
            base.Initialize(model);
        }
        
        private void InitialState()
        {
            setter.Display(false);
            setTimerButton.gameObject.SetActive(true);
            timer.Display(false);
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

        private void StartTimer(TimeSpan from)
        {
            setter.Display(false);
            timer.Display(true);
            timer.Model.ElapsedTime = (float)from.TotalSeconds;
            timer.Model.Run.Execute(true);
        }
    }
}