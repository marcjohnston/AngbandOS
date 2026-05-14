namespace AngbandOS.Core.Interface;

public class GameResults
{
    public bool GameIsOver { get; }
    public byte[] SerializedGameData { get; }

    public GameResults(bool gameIsOver, byte[] serializedGameData)
    {
        GameIsOver = gameIsOver;
        SerializedGameData = serializedGameData;
    }
}
