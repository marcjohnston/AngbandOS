namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighElfRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HighElfRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 2;
}