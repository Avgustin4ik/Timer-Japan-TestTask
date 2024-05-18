namespace Code.Core
{
    using Abstract;
    using Clock;
    using Models;
    using Panel.View;
    using Views;
    using Zenject;

    public class TimerMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //todo replace as single
            Container.Bind<SetterTimerModel>().AsSingle();
            Container.Bind<Views.StopwatchScreenModel>().AsSingle().NonLazy();
            Container.Bind<Models.StopwatchModel>().AsTransient().Lazy();
            Container.Bind<Models.ClockModel>().AsSingle();
            Container.Bind<TimerScreenModel>().AsSingle();
            Container.Bind<TimerModel>().AsSingle();
            Container.Bind<ClockScreenModel>().AsSingle();
            Container.Bind<ControlPanelModel>().AsSingle();
        }
    }
}