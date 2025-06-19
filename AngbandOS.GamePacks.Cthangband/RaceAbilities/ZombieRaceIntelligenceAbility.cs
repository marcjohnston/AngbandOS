namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ZombieRaceIntelligenceAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.ZombieRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Bonus => -6;
}