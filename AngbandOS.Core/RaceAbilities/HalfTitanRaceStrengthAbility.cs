namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfTitanRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTitanRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HalfTitanRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 5;
}