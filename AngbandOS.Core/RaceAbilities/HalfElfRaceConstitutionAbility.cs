namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfElfRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfElfRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HalfElfRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}