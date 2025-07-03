
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class MappedItemEnhancementGameConfiguration
{
    public virtual string? Key { get; set; } = null;

    /// <summary>
    /// Returns the fixed artifacts for the map entry; or null, for all fixed artifacts.
    /// </summary>
    public virtual string[]? FixedArtifactBindingKeys { get; set; }

    /// <summary>
    /// Returns the character classes for the map entry; or null, for all character classes.
    /// </summary>
    public virtual string[]? CharacterClassBindingKeys { get; set; }

    /// <summary>
    /// Returns the item enhancements to be used for the fixed artifact; or null, if there are no item enhancements.
    /// </summary>
    public virtual string[]? ItemEnhancementBindingKeys { get; set; }
}
