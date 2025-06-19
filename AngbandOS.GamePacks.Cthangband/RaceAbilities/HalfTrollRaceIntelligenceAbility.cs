namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfTrollRaceIntelligenceAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfTrollRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Bonus => -4;
}