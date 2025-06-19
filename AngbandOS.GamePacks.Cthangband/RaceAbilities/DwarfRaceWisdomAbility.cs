namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DwarfRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.DwarfRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 2;
}