namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GreatOneRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GreatOneRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private GreatOneRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}