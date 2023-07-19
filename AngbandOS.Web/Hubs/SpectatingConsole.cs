using AngbandOS.Core.Interface;

namespace AngbandOS.Web.Hubs;

public class SpectatingConsole : IConsole
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

    public char WaitForKey()
    {
        throw new NotImplementedException();
    }

    public bool KeyQueueIsEmpty()
    {
        throw new NotImplementedException();
    }

    public void MessagesUpdated()
    {
        throw new NotImplementedException();
    }
}
