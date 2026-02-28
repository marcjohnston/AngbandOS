namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatOneRaceDreamingPowerRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(GreatOneRaceDreamingPowerRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.GreatOneRaceDreamingPowerRacialPowerScript) };
}