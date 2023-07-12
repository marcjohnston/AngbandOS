using AngbandOS.Core.Interface;

namespace AngbandOS.Web.Hubs;

public class SpectatorConsole : IConsole
{
    private readonly ISpectatorsHub _gameHub;

    public SpectatorConsole(ISpectatorsHub gameHub)
    {
        _gameHub = gameHub;
    }

    public void Clear()
    {
        _gameHub.Clear();
    }

    public void PlayMusic(MusicTrackEnum music)
    {
        _gameHub.PlayMusic(music);
    }

    public void PlaySound(SoundEffectEnum sound)
    {
        _gameHub.PlaySound(sound);
    }

    public void BatchPrint(PrintLine[] printLines)
    {
        _gameHub.BatchPrint(printLines);
    }

    public void SetBackground(BackgroundImageEnum image)
    {
        _gameHub.SetBackground(image);
    }

    public char WaitForKey()
    {
        throw new NotImplementedException();
    }
}
