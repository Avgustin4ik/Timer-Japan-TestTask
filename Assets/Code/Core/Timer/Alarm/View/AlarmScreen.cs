namespace Code.Core.Timer.Alarm.View
{
    using System;
    using Abstract;
    using Audio;
    using AudioService;
    using Panel.View;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;
    using Views;
    using Zenject;

    public class AlarmScreen : UiView<ScreenModel>
    {
        [SerializeField] private Button stopAlarmButton;
        [Inject] private IAudioService _audioAudioService;
        [Inject] private TimerModel _timer;
        protected override void Initialize(ScreenModel model)
        {
            base.Initialize(model);
            stopAlarmButton.onClick.AddListener(StopAlarm);
            _timer.IsElapsed.Subscribe(Display).AddTo(this);
            _timer.IsElapsed.Subscribe(PlayAlarmSound).AddTo(this);
            Display(false);
        }


        private void StopAlarm()
        {
            _audioAudioService.StopAlarm();
            Display(false);
            _timer.Reset.Execute(true);
        }
        private void PlayAlarmSound(bool isElapsed)
        {
            if (!isElapsed) return;
            _audioAudioService.PlayAlarm();
            return;
        }
    }
}