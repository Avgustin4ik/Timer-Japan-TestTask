namespace Code.Core.Audio
{
    using UnityEngine;
    using Zenject;

    public class AudioFactory : PlaceholderFactory<AudioSource>
    {
        public override AudioSource Create()
        {
            return base.Create();
        }
    }
}