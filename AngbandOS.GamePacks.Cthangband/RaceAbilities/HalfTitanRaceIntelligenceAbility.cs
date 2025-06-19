namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfTitanRaceIntelligenceAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfTitanRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Bonus => 1;
}