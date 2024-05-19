namespace Code.Core
{
    using Audio;
    using UnityEngine;
    using Views;
    using Zenject;

    public class PrefabInstaller : MonoInstaller
    {
        public LapTimeView lapTimeViewPrefab;
        public AudioSource audioSourcePrefab;
        public override void InstallBindings()
        {
            Container.BindFactory<LapTimeView, LapTimeView.Factory>().FromComponentInNewPrefab(lapTimeViewPrefab);
            Container.BindFactory<AudioSource, AudioFactory>().FromComponentInNewPrefab(audioSourcePrefab).Lazy();
        }
    }
}