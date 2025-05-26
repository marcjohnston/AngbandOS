namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ImpRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ImpRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private ImpRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}