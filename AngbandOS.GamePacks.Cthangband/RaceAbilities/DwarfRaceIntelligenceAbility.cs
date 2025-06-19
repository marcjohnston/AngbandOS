namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DwarfRaceIntelligenceAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.DwarfRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Bonus => -2;
}