
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class MappedItemEnhancementGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Fixed Artifact Binding Keys",
        Summary = "Specifies the fixed artifacts for the map entry. When null, applies to all fixed artifacts.",
        DataType = "string[]?")]
    public virtual string[]? FixedArtifactBindingKeys { get; set; }

    [ConfigurationMetadata(
        Title = "Character Class Binding Keys",
        Summary = "Specifies the character classes for the map entry. When null, applies to all character classes.",
        DataType = "string[]?")]
    public virtual string[]? CharacterClassBindingKeys { get; set; }

    [ConfigurationMetadata(
        Title = "Item Enhancement Binding Keys",
        Summary = "Specifies the item enhancements to be used for the fixed artifact. When null, no item enhancements are applied.",
        DataType = "string[]?")]
    public virtual string[]? ItemEnhancementBindingKeys { get; set; }
}
