namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SkeletonRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SkeletonRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private SkeletonRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}