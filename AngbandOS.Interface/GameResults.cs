namespace AngbandOS.Core.Interface;

public class GameResults
{
    public bool GameIsOver { get; }
    public string? SerializedGameData { get; }

    public GameResults(bool gameIsOver, string? serializedGameData = null)
    {
        GameIsOver = gameIsOver;
        SerializedGameData = serializedGameData;
    }
}
