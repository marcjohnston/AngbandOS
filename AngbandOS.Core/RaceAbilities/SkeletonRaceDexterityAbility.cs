namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SkeletonRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SkeletonRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private SkeletonRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}