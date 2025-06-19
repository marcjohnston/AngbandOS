namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SkeletonRaceIntelligenceAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.SkeletonRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Bonus => -2;
}