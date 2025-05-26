namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GolemRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GolemRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private GolemRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}