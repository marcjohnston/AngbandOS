namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class MindFlayerRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MindFlayerRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private MindFlayerRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -5;
}