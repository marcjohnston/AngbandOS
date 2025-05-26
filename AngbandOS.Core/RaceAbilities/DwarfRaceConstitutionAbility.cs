namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DwarfRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DwarfRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private DwarfRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}