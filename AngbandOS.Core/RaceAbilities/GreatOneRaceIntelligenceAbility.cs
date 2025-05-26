namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GreatOneRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GreatOneRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private GreatOneRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}