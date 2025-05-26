namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfTitanRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTitanRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HalfTitanRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}