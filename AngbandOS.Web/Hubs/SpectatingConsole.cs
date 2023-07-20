using AngbandOS.Core.Interface;

namespace AngbandOS.Web.Hubs;

public class SpectatingConsole : ISpectator
{
    private readonly ISpectatingHub _gameHub;

    public SpectatingConsole(ISpectatingHub gameHub)
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
    public void MessagesUpdated()
    {
        throw new NotImplementedException();
    }
}
