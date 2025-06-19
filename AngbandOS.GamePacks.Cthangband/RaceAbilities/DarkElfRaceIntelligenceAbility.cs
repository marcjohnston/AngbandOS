namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DarkElfRaceIntelligenceAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.DarkElfRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Bonus => 3;
}