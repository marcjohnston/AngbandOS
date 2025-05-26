namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HobbitRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HobbitRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HobbitRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}