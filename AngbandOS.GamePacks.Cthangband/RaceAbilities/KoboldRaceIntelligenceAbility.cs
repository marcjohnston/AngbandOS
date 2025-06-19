namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class KoboldRaceIntelligenceAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.KoboldRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Bonus => -1;
}