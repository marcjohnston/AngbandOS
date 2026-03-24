namespace AngbandOS.Core.Interface;

public class GameResults
{
    public bool GameIsOver { get; }

    public GameResults(bool gameIsOver)
    {
        GameIsOver = gameIsOver;
    }
}
