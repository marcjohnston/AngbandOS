namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HumanRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HumanRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HumanRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}