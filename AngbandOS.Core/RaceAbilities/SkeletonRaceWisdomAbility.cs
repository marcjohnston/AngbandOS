namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SkeletonRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SkeletonRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private SkeletonRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}