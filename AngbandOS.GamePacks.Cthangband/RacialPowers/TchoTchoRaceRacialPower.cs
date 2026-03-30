namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TchoTchoRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(TchoTchoRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.TchoTchoRace);
}