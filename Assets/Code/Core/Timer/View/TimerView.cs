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
        [SerializeField] private Button startButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resetButton;
        
        
        private IDisposable _timerRx;
        
        [Inject]
        protected override void Initialize(TimerModel model)
        {
            pauseButton.OnClickAsObservable().Subscribe(x=>Pause()).AddTo(this);
            startButton.OnClickAsObservable().Subscribe(x=>Run()).AddTo(this);
            resetButton.OnClickAsObservable().Subscribe(x=>Reset()).AddTo(this);
            
            model.Time.Subscribe(x=>DisplayTime(x)).AddTo(this);
            model.Run.Subscribe(_ => Run()).AddTo(this);
            model.IsElapsed.Subscribe(PlayAlarm).AddTo(this);
            base.Initialize(model);
        }

        private void PlayAlarm(bool isElapsed)
        {
            if(!isElapsed) return;
            Stop();
            startButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(false);
#if UNITY_EDITOR
            Debug.LogError("not implemented yet");
#endif
        }

        private void Reset()
        {
            Stop();
            Model.ResetValues();
            Model.Reset.Execute(true);
            pauseButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(true);
        }

        private void Pause()
        {
            pauseButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(true);
            
            Model.IsClearStart = false;
            Model.LastPauseTime = Time.time;
            Stop();
        }
        
        
        private void Stop()
        {
            if (_timerRx != null)
                _timerRx.Dispose();
        }


        private void DisplayTime(TimeSpan timeSpan)
        {
            timeText.text = timeSpan.ToString(@"hh\:mm\:ss");
        }

        public void Run()
        {
            pauseButton.gameObject.SetActive(true);
            startButton.gameObject.SetActive(false);
            
            if (Model.IsClearStart)
                Model.StartTime = Time.time;
            else
                Model.PauseDuration += Time.time - Model.LastPauseTime;
            
            _timerRx = Observable.Interval(TimeSpan.FromMilliseconds(1)).Subscribe(_ =>
            {
                Model.Time.Value = TimeSpan.FromSeconds(Model.ElapsedTime - (Time.time - Model.StartTime - Model.PauseDuration));
            });
        }
    }
}