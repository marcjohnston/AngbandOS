using Cthangband.Terminal;

namespace Cthangband
{
    public interface IConsole
    {
        void SetCellBackground(int row, int col, char c, string color);
        void UnsetCellBackground(int row, int col, char c, string color);
        void Clear();
        void Print(int row, int col, string text, string colour);
        char WaitForKey();
        void SetBackground(BackgroundImage image);
        void PlaySound(SoundEffect sound);
        void PlayMusic(MusicTrack music);
    }
}
