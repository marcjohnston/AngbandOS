namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CyclopsRaceIntelligenceAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.CyclopsRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Bonus => -3;
}