namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class CyclopsRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(CyclopsRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private CyclopsRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}