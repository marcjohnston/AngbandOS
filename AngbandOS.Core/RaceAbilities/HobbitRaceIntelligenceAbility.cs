namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HobbitRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HobbitRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HobbitRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}