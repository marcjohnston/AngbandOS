namespace AngbandOS.GamePacks.Cthangband;

public class HobbitRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(HobbitRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HobbitRacialPowerScript) };
}