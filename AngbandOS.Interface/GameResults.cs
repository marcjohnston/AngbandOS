namespace AngbandOS.Core.Interface;

public class GameResults
{
    public bool IsDead { get; }
    public string CharacterName { get; }
    public int Level { get; }
    public int Gold { get; }

    public byte[] SerializedGameData { get; }

    public GameResults(bool isDead, string characterName, int level, int gold, byte[] serializedGameData)
    {
        IsDead = isDead;
        CharacterName = characterName;
        Level = level;
        Gold = gold;
        SerializedGameData = serializedGameData;
    }
}
