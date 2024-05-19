namespace Code.Core.Audio
{
    using System;
    using UnityEngine;
    using Zenject;

    [CreateAssetMenu(menuName = "Configs/Audio Map", fileName = "AudioMap")]
    public class AudioMap : ScriptableObject
    {
        [SerializeField] private AudioClip _alarmSound;
        public AudioClip AlarmSound => _alarmSound;
    }
}