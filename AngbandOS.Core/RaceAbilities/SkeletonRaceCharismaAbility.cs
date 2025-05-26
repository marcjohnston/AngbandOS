namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SkeletonRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SkeletonRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private SkeletonRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}