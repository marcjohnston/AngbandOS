
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class SpellGameConfiguration
{
    public virtual string Key { get; set; }

    /// <summary>
    /// Returns the name of the spell, as rendered to the SaveGame.
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// Returns details about the spell, blank if there are no details or null, if the details should be retrieved from the
    /// associated scripts that are configured when the spell succeeds.  Returns null, by default.
    /// </summary>
    /// <returns></returns>
    public virtual string? LearnedDetails { get; set; } = null;
}
