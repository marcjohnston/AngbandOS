namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfOrcRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOrcRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HalfOrcRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}