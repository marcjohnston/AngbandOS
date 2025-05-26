namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfTrollRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTrollRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HalfTrollRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}