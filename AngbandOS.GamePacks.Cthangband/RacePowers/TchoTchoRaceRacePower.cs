namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TchoTchoRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(TchoTchoRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.TchoTchoRace);
}