namespace AngbandOS.Core.Interface;

public interface IConsole
{
    void Clear();
    void BatchPrint(PrintLine[] printLines);
    char WaitForKey();
    void SetBackground(BackgroundImage image);
    void PlaySound(SoundEffect sound);
    void PlayMusic(MusicTrack music);
}