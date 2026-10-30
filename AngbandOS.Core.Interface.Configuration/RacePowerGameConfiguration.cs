using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RacePowerGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RaceBindingKey, CharacterClassBindingKey, nameof(RacePowerGameConfiguration) }; // CONFIRMED, TODO: WHY FIXED 3RD KEY?

    [ConfigurationMetadata(
        Title = "Script Binding Key",
        Summary = "Specifies the binding key of the script executed by the racial power.",
        DataType = "string")]
    public virtual string ScriptBindingKey { get; set; }

    [ConfigurationMetadata(
        Title = "Race Binding Key",
        Summary = "Specifies the binding key of the associated race.",
        DataType = "string")]
    public virtual string RaceBindingKey { get; set; }

    [ConfigurationMetadata(
        Title = "Character Class Binding Key",
        Summary = "Specifies the optional binding key of the associated character class.",
        DataType = "string?")]
    public virtual string? CharacterClassBindingKey { get; set; } = null;
}

