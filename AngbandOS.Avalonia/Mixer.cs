using AngbandOS.Core.Interface;

namespace AngbandOS.Avalonia
{
    internal class Mixer
    {
        public float MusicVolume = 1;
        public float SoundVolume = 1;
        public void Initialize(float m, float s) { MusicVolume = m; SoundVolume = s; }
        public void Play(MusicTrackEnum t) { }
        public void Play(SoundEffectEnum s) { }
    }
}