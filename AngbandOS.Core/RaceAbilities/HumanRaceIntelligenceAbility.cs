namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HumanRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HumanRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HumanRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}