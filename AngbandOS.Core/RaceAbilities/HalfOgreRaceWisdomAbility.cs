namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfOgreRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOgreRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HalfOgreRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}