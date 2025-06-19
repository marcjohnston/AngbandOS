namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SkeletonRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.SkeletonRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => 0;
}