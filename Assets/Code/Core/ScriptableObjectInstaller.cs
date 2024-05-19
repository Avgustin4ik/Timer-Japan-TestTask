using Code.Core.Audio;
using Code.Core.AudioService;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableObjectInstaller", menuName = "Installers/ScriptableObjectInstaller")]
public class ScriptableObjectInstaller : ScriptableObjectInstaller<ScriptableObjectInstaller>
{
    [SerializeField] private AudioMap audioMap;
    public override void InstallBindings()
    {
        Container.Bind<AudioMap>().To<AudioMap>().FromInstance(audioMap).AsSingle().NonLazy();
    }
}