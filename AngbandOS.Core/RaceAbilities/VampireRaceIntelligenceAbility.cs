namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class VampireRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(VampireRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private VampireRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}