namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MindFlayerRaceIntelligenceAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.MindFlayerRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Bonus => 4;
}