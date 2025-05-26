namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class YeekRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(YeekRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private YeekRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}