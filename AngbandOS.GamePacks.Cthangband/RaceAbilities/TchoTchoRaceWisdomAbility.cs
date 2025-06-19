namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TchoTchoRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.TchoTchoRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => -1;
}