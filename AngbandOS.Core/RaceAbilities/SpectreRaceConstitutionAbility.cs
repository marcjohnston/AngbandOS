namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SpectreRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpectreRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private SpectreRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}