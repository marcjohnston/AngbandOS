namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TchoTchoRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.TchoTchoRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 3;
}