namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MindFlayerRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(MindFlayerRaConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.MindFlayerRacialPowerScript) };
}