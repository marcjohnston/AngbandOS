namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class KoboldRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KoboldRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private KoboldRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}