namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfOrcRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOrcRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HalfOrcRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}