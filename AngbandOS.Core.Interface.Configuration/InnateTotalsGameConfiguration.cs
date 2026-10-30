using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class InnateTotalsGameConfiguration : CompositeSingletonGameConfiguration
{
    public override string?[] CompositeKeys => new string?[] { CharacterClassBindingKey, RaceBindingKey };

    [ConfigurationMetadata(Title = "Character Class Binding Key", Summary = "The binding key of the character class associated with these innate totals.", DataType = "string?")]
    public virtual string? CharacterClassBindingKey { get; set; } = null;

    [ConfigurationMetadata(Title = "Race Binding Key", Summary = "The binding key of the race associated with these innate totals.", DataType = "string?")]
    public virtual string? RaceBindingKey { get; set; } = null;

    [ConfigurationMetadata(Title = "Maximum Innates", Summary = "The maximum number of innate abilities available for each innate ability category.", DataType = "int[]")]
    public virtual int[] MaxInnates { get; set; }
}