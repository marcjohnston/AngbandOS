namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SkeletonRaceConstitutionAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.SkeletonRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Bonus => 1;
}