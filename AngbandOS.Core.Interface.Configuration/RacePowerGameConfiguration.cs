using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RacePowerGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RaceBindingKey, CharacterClassBindingKey, nameof(RacePowerGameConfiguration) }; // CONFIRMED, TODO: WHY FIXED 3RD KEY?

    [ConfigurationProperty("string",
        Title = "Script Binding Key",
        Description = "Specifies the binding key of the script executed by the racial power.")]
    public virtual string ScriptBindingKey { get; set; }

    [ConfigurationProperty("string",
        Title = "Race Binding Key",
        Description = "Specifies the binding key of the associated race.")]
    public virtual string RaceBindingKey { get; set; }

    [ConfigurationProperty("string?",
        Title = "Character Class Binding Key",
        Description = "Specifies the optional binding key of the associated character class.")]
    public virtual string? CharacterClassBindingKey { get; set; } = null;
}

