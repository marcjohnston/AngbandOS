namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HobbitRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HobbitRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HobbitRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}