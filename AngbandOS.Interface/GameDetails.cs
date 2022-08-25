namespace AngbandOS.Interface;

/// <summary>
/// Represents additional game details that can be saved alongside the game data.
/// </summary>
public class GameDetails
{
    public int Level { get; set; }
    public int Gold { get; set; }
    public string CharacterName { get; set; }
    public string Comments { get; set; }
    public bool IsAlive { get; set; }
}
