

namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class SpellGameConfiguration
{
    public virtual string Key { get; set; }

    /// <summary>
    /// Returns the name of the spell, as rendered to the SaveGame.
    /// </summary>
    public virtual string Name { get; set; }
    public virtual string[]? CastScriptNames { get; set; } = null;
    public virtual string[]? CastFailedScriptNames { get; set; } = null;
    public virtual string LearnedDetails { get; set; } = "";
}
