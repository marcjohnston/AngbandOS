namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class VampireRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(VampireRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private VampireRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}