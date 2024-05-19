namespace Code.Core
{
    using Abstract;
    using AudioService;
    using Clock;
    using Models;
    using Panel.View;
    using Timer.Alarm.View;
    using Views;
    using Zenject;

    public class TimerMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ScreenModel>().AsTransient().Lazy();
            Container.Bind<SetterTimerModel>().AsSingle();
            Container.Bind<Models.StopwatchModel>().AsSingle();
            Container.Bind<Models.ClockModel>().AsSingle();
            Container.Bind<TimerModel>().AsSingle();
            Container.Bind<ControlPanelModel>().AsSingle();
            Container.Bind<LapTimeModel>().AsTransient().Lazy();
            Container.Bind<IAudioService>().To<Audio.AudioService>().AsSingle().Lazy();

        }
    }
}