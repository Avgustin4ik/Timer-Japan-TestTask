namespace Code.Core.Views
{
    using System;
    using Abstract;
    using Timer.Model;
    using TMPro;
    using UniRx;
    using UnityEngine.UI;
    using Zenject;

    public class TimerView : UiView<TimerModel>
    {
        public TextMeshProUGUI Time;
        public Button Start;
        public Button Pause;
        public Button Cancel;
        public SetterTimerView SetterTimer;
        
        [Inject]
        protected override void Initialize(TimerModel model)
        {
            Model.Time.Subscribe(x => Time.text = x.ToString(@"hh\:mm\:ss")).AddTo(this);
            Model.Run.Subscribe(_ => Run()).AddTo(this);
            Model.Pause.Subscribe(_ => PauseTimer()).AddTo(this);
            Model.Reset.Subscribe(_ => ResetTimer()).AddTo(this);
            base.Initialize(model);
        }

        private void ResetTimer()
        {
            throw new NotImplementedException();
        }

        private void PauseTimer()
        {
            throw new NotImplementedException();
        }

        private void Run()
        {
            // if(Model.IsClearStart)
            //     Model.StartTime = Time.time;
            // else
            //     Model.PauseDuration += Time.time - Model.LastPauseTime;
            // _timerRx = Observable.EveryUpdate().Subscribe(_ =>
            // {
            //     var time = Time.time - Model.StartTime - Model.PauseDuration;
            //     Model.Time.Value = TimeSpan.FromSeconds(time);
            // });
        }
    }
}