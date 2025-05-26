namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ElfRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ElfRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private ElfRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}