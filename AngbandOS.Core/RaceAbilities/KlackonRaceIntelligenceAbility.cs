namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class KlackonRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KlackonRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private KlackonRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}