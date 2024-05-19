namespace Code.Core.Audio
{
    using System.Collections.Generic;
    using Core.AudioService;
    using UnityEngine;
    using Zenject;

    public class AudioService : IAudioService
    {
        private List<AudioSource> cashedAudioSources = new List<AudioSource>();
        
        [Inject] AudioMap _audioMap;
        [Inject] AudioFactory _audioFactory;
        
        public void PlaySound(AudioClip clip)
        {
            var audioSource = _audioFactory.Create();
            audioSource.clip = clip;
            cashedAudioSources.Add(audioSource);
        }
        
        public void PlayAlarm()
        {
            PlaySound(_audioMap.AlarmSound);
        }

        public void StopAlarm()
        {
            foreach (var source in cashedAudioSources)
            {
                Object.Destroy(source.gameObject);
            }
            cashedAudioSources.Clear();
        }
    }
}