namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GolemRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GolemRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private GolemRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -5;
}