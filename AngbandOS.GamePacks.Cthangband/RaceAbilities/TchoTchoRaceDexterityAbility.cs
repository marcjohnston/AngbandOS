namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TchoTchoRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.TchoTchoRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => 1;
}