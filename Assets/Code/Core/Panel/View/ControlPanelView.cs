namespace Code.Core.Panel.View
{
    using Abstract;
    using Clock;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;
    using Views;
    using Zenject;

    public class ControlPanelView : UiView<ControlPanelModel>
    {
        [Header("Buttons")]
        [SerializeField] private Button ClockButton;
        [SerializeField] private Button TimerButton;
        [SerializeField] private Button AlarmButton;
        
        [Header("Screens")]
        [SerializeField] private ClockScreenView ClockScreen;
        [SerializeField] private TimerScreenView TimerScreen;
        [SerializeField] private StopwatchScreenView AlarmScreen;
        
        public void InitialState()
        {
            ClockScreen.Display(true);
            TimerScreen.Display(false);
            AlarmScreen.Display(false);
        }
        [Inject]
        protected override void Initialize(ControlPanelModel model)
        {
            ClockButton.onClick.AsObservable().Subscribe(x => ShowClockScreen());
            TimerButton.onClick.AsObservable().Subscribe(x => ShowTimerScreen());
            AlarmButton.onClick.AsObservable().Subscribe(x => ShowAlarmScreen());
            
            base.Initialize(model);
            
        }

        private void ShowClockScreen()
        {
            ClockScreen.Display(true);
            TimerScreen.Display(false);
            AlarmScreen.Display(false);
        }
        
        private void ShowTimerScreen()
        {
            ClockScreen.Display(false);
            TimerScreen.Display(true);
            AlarmScreen.Display(false);
        }
        
        private void ShowAlarmScreen()
        {
            ClockScreen.Display(false);
            TimerScreen.Display(false);
            AlarmScreen.Display(true);
        }
    }
}