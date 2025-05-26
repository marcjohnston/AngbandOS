namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SkeletonRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SkeletonRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private SkeletonRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}