namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfOgreRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOgreRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HalfOgreRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}