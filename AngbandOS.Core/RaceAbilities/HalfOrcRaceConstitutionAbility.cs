namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfOrcRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOrcRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HalfOrcRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}