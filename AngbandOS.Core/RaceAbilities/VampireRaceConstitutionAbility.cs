namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class VampireRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(VampireRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private VampireRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}