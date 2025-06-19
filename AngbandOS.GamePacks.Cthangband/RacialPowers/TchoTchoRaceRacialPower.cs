namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TchoTchoRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(TchoTchoRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.TchoTchoRace);
}