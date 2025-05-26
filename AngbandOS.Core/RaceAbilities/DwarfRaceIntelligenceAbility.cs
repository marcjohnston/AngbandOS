namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DwarfRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DwarfRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private DwarfRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}