namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SkeletonRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.SkeletonRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 0;
}