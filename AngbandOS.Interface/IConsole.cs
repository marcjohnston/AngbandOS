using System.Drawing;

namespace AngbandOS.Interface;

public interface IConsole
{
    void SetCellBackground(int row, int col, char c, Colour colour);
    void UnsetCellBackground(int row, int col, char c, Colour colour);
    void Clear();
    void Print(int row, int col, string text, Colour colour);
    char WaitForKey();
    void SetBackground(BackgroundImage image);
    void PlaySound(SoundEffect sound);
    void PlayMusic(MusicTrack music);
}
