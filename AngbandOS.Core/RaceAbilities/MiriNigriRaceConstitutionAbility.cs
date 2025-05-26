namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class MiriNigriRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MiriNigriRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private MiriNigriRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}