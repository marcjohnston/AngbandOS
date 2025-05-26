namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GnomeRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GnomeRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private GnomeRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}