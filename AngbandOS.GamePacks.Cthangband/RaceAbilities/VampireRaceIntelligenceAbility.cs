namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class VampireRaceIntelligenceAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.VampireRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Bonus => 3;
}