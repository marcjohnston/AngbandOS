namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfTitanRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTitanRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HalfTitanRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}