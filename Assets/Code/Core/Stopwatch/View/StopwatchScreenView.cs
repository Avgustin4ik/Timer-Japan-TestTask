namespace Code.Core.Views
{
    using System;
    using Abstract;
    using Panel.View;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    public class StopwatchScreenView : ScreenView
    {
        public Button startButton;
        public Button pauseButton;
        public Button resetButton;
        public Button lapButton;
        [SerializeField] private StopwatchView stopwatchView;
        [Inject]
        protected override void Initialize(ScreenModel model)
        {
            startButton.onClick.AsObservable().Subscribe(x => RunStopwatch());
            pauseButton.onClick.AsObservable().Subscribe(x => PauseStopwatch());
            resetButton.onClick.AsObservable().Subscribe(x => ResetStopwatch());
            lapButton.onClick.AsObservable().Subscribe(x => LapStopwatch());
            
            base.Initialize(model);
        }

        private void RunStopwatch()
        {
            stopwatchView.Model.Run.Execute(true);
            startButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            resetButton.gameObject.SetActive(false);
            lapButton.gameObject.SetActive(true);
        }
        
        private void PauseStopwatch()
        {
            stopwatchView.Model.Pause.Execute(true);
            startButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(true);
            lapButton.gameObject.SetActive(false);
        }
        
        private void ResetStopwatch()
        {
            stopwatchView.Model.Reset.Execute(true);
            startButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(true);
            lapButton.gameObject.SetActive(false);
        }
        
        private void LapStopwatch()
        {
            stopwatchView.Model.Lap.Execute(true);
        }
    }
}