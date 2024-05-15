namespace Code.Core.Views
{
    using System;
    using Abstract;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    public class StopwatchScreenView : UiView<StopwatchScreenModel>
    {
        public Button startButton;
        public Button pauseButton;
        public Button resetButton;
        public Button lapButton;
        [SerializeField] private StopwatchView stopwatchView;
        [Inject]
        protected override void Initialize(StopwatchScreenModel model)
        {
            // startButton.onClick.AsObservable().Take(1).Subscribe(x => RunStopwatch());
            // pauseButton.onClick.AsObservable().Subscribe(x => model.Pause.Execute(true));
            // resetButton.onClick.AsObservable().Subscribe(x => model.Reset.Execute(true));
            // lapButton.onClick.AsObservable().Subscribe(x => model.Lap.Execute(true));
            
            
            // model.Run.Subscribe(_=>RunStopwatch()).AddTo(this);
            // model.Pause.Subscribe(_=>PauseStopwatch()).AddTo(this);
            // model.Reset.Subscribe(_=>ResetStopwatch()).AddTo(this);
            // model.Lap.Subscribe(_=>LapStopwatch()).AddTo(this);
            base.Initialize(model);
        }

        private void RunStopwatch()
        {
            Debug.Log("RunStopwatch");
            startButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            resetButton.gameObject.SetActive(false);
            lapButton.gameObject.SetActive(true);
        }
        
        private void PauseStopwatch()
        {
            startButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(true);
            lapButton.gameObject.SetActive(false);
        }
        
        private void ResetStopwatch()
        {
            startButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(false);
            lapButton.gameObject.SetActive(true);
        }
        
        private void LapStopwatch()
        {
            throw new NotImplementedException("LapStopwatch not implemented yet!");
        }
    }
}