namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TchoTchoRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.TchoTchoRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => -2;
}