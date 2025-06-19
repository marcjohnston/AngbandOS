namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SkeletonRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.SkeletonRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => -2;
}