namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DarkElfRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DarkElfRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private DarkElfRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}