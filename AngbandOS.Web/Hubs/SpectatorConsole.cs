using Cthangband;

namespace AngbandOS.Web.Hubs
{
    public class SpectatorConsole : IConsole
    {
        private readonly IGameHub _gameHub;

        public SpectatorConsole(IGameHub gameHub)
        {
            _gameHub = gameHub;
        }

        public void Clear()
        {
            _gameHub.Clear();
        }

        public void PlayMusic(MusicTrack music)
        {
            _gameHub.PlayMusic(music);
        }

        public void PlaySound(SoundEffect sound)
        {
            _gameHub.PlaySound(sound);
        }

        public void Print(int row, int col, string text, string colour)
        {
            _gameHub.Print(row, col, text, colour);
        }

        public void SetBackground(BackgroundImage image)
        {
            _gameHub.SetBackground(image);
        }

        public void SetCellBackground(int row, int col, char c, string color)
        {
            _gameHub.SetCellBackground(row, col, c, color);
        }

        public void UnsetCellBackground(int row, int col, char c, string color)
        {
            _gameHub.UnsetCellBackground(row, col, c, color);
        }

        public char WaitForKey()
        {
            throw new NotImplementedException();
        }
    }
}
