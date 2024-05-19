namespace Code.Core
{
    using Abstract;
    using AudioService;
    using Panel.View;
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

            
            Container.Bind<ControlPanelModel>().AsSingle();
            Container.Bind<LapTimeModel>().AsTransient().Lazy();
            Container.Bind<IAudioService>().To<Audio.AudioService>().AsSingle().Lazy();

            Container.Bind<TimerModel>().AsSingle().Lazy();
        }
    }
}