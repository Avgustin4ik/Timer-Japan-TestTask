namespace Code.Core.Views
{
    using Abstract;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;

    public class StopwatchScreenView : UiView<StopwatchScreenModel>
    {
        public Button startButton;
        public Button pauseButton;
        public Button resetButton;
        public Button lapButton;
        [SerializeField] private StopwatchView stopwatchView;
        protected override void Initialize(StopwatchScreenModel model)
        {
            startButton.onClick.AsObservable().Subscribe(x => model.Run.Execute(true));
            pauseButton.onClick.AsObservable().Subscribe(x => model.Pause.Execute(true));
            resetButton.onClick.AsObservable().Subscribe(x => model.Reset.Execute(true));
            lapButton.onClick.AsObservable().Subscribe(x => model.Lap.Execute(true));
            
            
            model.Run.Subscribe(_=>RunStopwatch()).AddTo(this);
            model.Pause.Subscribe(_=>PauseStopwatch()).AddTo(this);
            model.Reset.Subscribe(_=>ResetStopwatch()).AddTo(this);
            model.Lap.Subscribe(_=>LapStopwatch()).AddTo(this);
            base.Initialize(model);
        }

        private void RunStopwatch()
        {
            stopwatchView.Model.Run.Execute(true);
            startButton.enabled = false;
            pauseButton.enabled = true;
            resetButton.enabled = true;
            lapButton.enabled = true;
        }
        
        private void PauseStopwatch()
        {
            stopwatchView.Model.Pause.Execute(true);
            startButton.enabled = true;
            pauseButton.enabled = false;
            resetButton.enabled = true;
            lapButton.enabled = true;
        }
        
        private void ResetStopwatch()
        {
            stopwatchView.Model.Reset.Execute(true);
            startButton.enabled = true;
            pauseButton.enabled = false;
            resetButton.enabled = false;
            lapButton.enabled = false;
        }
        
        private void LapStopwatch()
        {
            stopwatchView.Model.Lap.Execute(true);
        }
    }
}