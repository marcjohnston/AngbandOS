namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfTitanRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTitanRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HalfTitanRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}