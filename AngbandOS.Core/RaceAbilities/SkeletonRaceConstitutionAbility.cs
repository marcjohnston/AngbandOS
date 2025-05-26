namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SkeletonRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SkeletonRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private SkeletonRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}