namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DwarfRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DwarfRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private DwarfRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}