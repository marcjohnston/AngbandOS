namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class MindFlayerRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MindFlayerRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private MindFlayerRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}