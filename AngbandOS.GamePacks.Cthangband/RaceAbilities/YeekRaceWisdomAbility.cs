namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class YeekRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.YeekRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 1;
}