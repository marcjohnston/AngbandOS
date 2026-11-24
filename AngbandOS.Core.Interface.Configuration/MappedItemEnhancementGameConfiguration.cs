
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class MappedItemEnhancementGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string[]?",
        Title = "Fixed Artifact Binding Keys",
        Description = "Specifies the fixed artifacts for the map entry. When null, applies to all fixed artifacts.")]
    public virtual string[]? FixedArtifactBindingKeys { get; set; }

    [ConfigurationProperty("string[]?",
        Title = "Character Class Binding Keys",
        Description = "Specifies the character classes for the map entry. When null, applies to all character classes.")]
    public virtual string[]? CharacterClassBindingKeys { get; set; }

    [ConfigurationProperty("string[]?",
        Title = "Item Enhancement Binding Keys",
        Description = "Specifies the item enhancements to be used for the fixed artifact. When null, no item enhancements are applied.")]
    public virtual string[]? ItemEnhancementBindingKeys { get; set; }
}
