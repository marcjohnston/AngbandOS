namespace AngbandOS.Core.Interface;

public interface IConsole
{
    void Clear();
    void Print(int row, int col, string text, Colour foreColour, Colour backColour);
    char WaitForKey();
    void SetBackground(BackgroundImage image);
    void PlaySound(SoundEffect sound);
    void PlayMusic(MusicTrack music);
}
