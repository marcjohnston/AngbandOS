namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class MindFlayerRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MindFlayerRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private MindFlayerRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}