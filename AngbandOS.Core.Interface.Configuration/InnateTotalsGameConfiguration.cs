using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class InnateTotalsGameConfiguration : CompositeSingletonGameConfiguration
{
    public override string?[] CompositeKeys => new string?[] { CharacterClassBindingKey, RaceBindingKey };

    [ConfigurationProperty("string?",
        Title = "Character Class Binding Key",
        Description = "The binding key of the character class associated with these innate totals.")]
    public virtual string? CharacterClassBindingKey { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Race Binding Key",
        Description = "The binding key of the race associated with these innate totals.")]
    public virtual string? RaceBindingKey { get; set; } = null;

    [ConfigurationProperty("int[]",
        Title = "Maximum Innates",
        Description = "The maximum number of innate abilities available for each innate ability category.")]
    public virtual int[] MaxInnates { get; set; }
}