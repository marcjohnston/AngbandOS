namespace AngbandOS.Core.Interface;

public class GameResults
{
    public bool Success { get; }
    public string Replay { get; }

    public GameResults(bool success, string replay)
    {
        Success = success;
        Replay = replay;
    }
}