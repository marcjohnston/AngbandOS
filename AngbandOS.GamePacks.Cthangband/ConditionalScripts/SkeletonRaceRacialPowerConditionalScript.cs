namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SkeletonRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(SkeletonRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.SkeletonRacialPowerScript) };
}