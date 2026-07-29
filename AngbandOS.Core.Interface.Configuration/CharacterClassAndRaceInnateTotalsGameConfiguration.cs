namespace AngbandOS.Core.Interface.Configuration;

public class CharacterClassAndRaceInnateTotalsGameConfiguration : CompositeSingletonGameConfiguration
{
    public override string?[] CompositeKeys => new string?[] { CharacterClassBindingKey, RaceBindingKey };
    public virtual string? CharacterClassBindingKey { get; set; } = null;
    public virtual string? RaceBindingKey { get; set; } = null;
    public virtual int[] MaxInnates { get; set; }
}
