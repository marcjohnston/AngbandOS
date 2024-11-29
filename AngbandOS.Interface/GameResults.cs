namespace AngbandOS.Core.Interface;

public class GameResults
{
    public bool GameIsOver { get; }
    public string Replay { get; }

    public GameResults(bool gameIsOver, string replay)
    {
        GameIsOver = gameIsOver;
        Replay = replay;
    }
}