namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfOgreRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOgreRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HalfOgreRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}