namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TchoTchoRaceIntelligenceAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.TchoTchoRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Bonus => -2;
}