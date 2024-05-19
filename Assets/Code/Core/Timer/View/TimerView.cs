namespace Code.Core.Views
{
    using System;
    using Abstract;
    using TMPro;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    public class TimerView : UiView<TimerModel>
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resetButton;
        
        protected override void Initialize(TimerModel model)
        {
            pauseButton.OnClickAsObservable().Subscribe(x=>Pause()).AddTo(this);
            resumeButton.OnClickAsObservable().Subscribe(x=>Resume()).AddTo(this);
            resetButton.OnClickAsObservable().Subscribe(x=>Reset()).AddTo(this);
            
            model.Time.Subscribe(DisplayTime).AddTo(this);
            model.IsElapsed.Subscribe(PlayAlarm).AddTo(this);
            base.Initialize(model);
            InitialState();
        }

        public void InitialState()
        {
            resumeButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
        }

        private void PlayAlarm(bool isElapsed)
        {
            if(!isElapsed) return;
            InitialState();
        }

        public void Reset()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);
            Model.Reset();
        }

        private void Pause()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);
            Model.Pause();
        }

        private void DisplayTime(TimeSpan timeSpan)
        {
            timeText.text = timeSpan.ToString(@"hh\:mm\:ss");
        }

        private void Resume()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
            Model.Run();
        }
    }
}