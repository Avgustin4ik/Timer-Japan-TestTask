namespace Code.Core
{
    using Abstract;
    using Models;
    using Zenject;

    public class TimerMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //todo replace as single
            Container.Bind<Views.StopwatchScreenModel>().AsSingle().NonLazy();
            Container.Bind<Models.StopwatchModel>().AsTransient().Lazy();
            Container.Bind<Models.ClockModel>().AsSingle();
        }
    }
}