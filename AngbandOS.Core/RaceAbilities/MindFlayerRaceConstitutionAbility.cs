namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class MindFlayerRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MindFlayerRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private MindFlayerRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}