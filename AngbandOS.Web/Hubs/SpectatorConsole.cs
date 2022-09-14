using AngbandOS.Core.Interface;

namespace AngbandOS.Web.Hubs;

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

    public void Print(int row, int col, string text, Colour foreColour, Colour backColour)
    {
        _gameHub.Print(row, col, text, foreColour, backColour);
    }

    public void SetBackground(BackgroundImage image)
    {
        _gameHub.SetBackground(image);
    }

    public char WaitForKey()
    {
        throw new NotImplementedException();
    }
}
