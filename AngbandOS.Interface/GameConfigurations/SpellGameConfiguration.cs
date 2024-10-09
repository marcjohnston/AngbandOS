

namespace AngbandOS.Core.Interface;

[Serializable]
public class SpellGameConfiguration : IGameConfiguration
{
    public virtual string Key { get; set; }

    /// <summary>
    /// Returns the name of the spell, as rendered to the SaveGame.
    /// </summary>
    public virtual string Name { get; set; }
    public virtual string? CastScriptName { get; set; } = null;
    public virtual string? CastFailedScriptName { get; set; } = null;
    public virtual string LearnedDetails { get; set; } = "";

    public bool IsValid()
    {
        return true;
    }

    public override string ToString()
    {
        return Key;
    }
}
