namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TchoTchoRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(TchoTchoRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.TchoTchoRacialPowerScript) };
}