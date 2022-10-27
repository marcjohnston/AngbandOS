namespace AngbandOS.Web.Interface;

/// <summary>
/// Represents the save game details model for a persistent storage driver.
/// </summary>
public class SavedGameDetails
{
    public string Guid { get; set; }
    public DateTimeOffset SavedDateTime { get; set; }
    public int Level { get; set; }
    public int Gold { get; set; }
    public string CharacterName { get; set; }
    public string Comments { get; set; }
    public bool IsAlive { get; set; }
}
