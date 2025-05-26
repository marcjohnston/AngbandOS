namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HumanRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HumanRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HumanRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}