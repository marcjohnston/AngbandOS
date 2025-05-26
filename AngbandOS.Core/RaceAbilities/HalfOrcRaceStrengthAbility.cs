namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfOrcRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOrcRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HalfOrcRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}