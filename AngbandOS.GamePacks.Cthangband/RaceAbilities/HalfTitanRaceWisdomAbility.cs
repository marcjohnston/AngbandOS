namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfTitanRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfTitanRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 1;
}