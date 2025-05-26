namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class YeekRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(YeekRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private YeekRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}