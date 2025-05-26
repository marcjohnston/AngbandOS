namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class MindFlayerRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MindFlayerRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private MindFlayerRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}