namespace Code.Core.Timer.Alarm.View
{
    using Abstract;
    using Panel.View;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;
    using Views;
    using Zenject;

    public class AlarmScreen : UiView<ScreenModel>
    {
        [SerializeField] private Button stopAlarmButton;
        
        [Inject] private TimerModel _timer;
        protected override void Initialize(ScreenModel model)
        {
            base.Initialize(model);
            stopAlarmButton.onClick.AddListener(() => StopAlarm());
            _timer.IsElapsed.Subscribe(x => Display(x)).AddTo(this);
            Display(false);
        }

        private void StopAlarm()
        {
            Display(false);
            _timer.Reset.Execute(true);
        }
    }
}