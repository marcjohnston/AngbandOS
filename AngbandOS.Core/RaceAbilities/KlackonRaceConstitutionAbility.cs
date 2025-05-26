namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class KlackonRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KlackonRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private KlackonRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}