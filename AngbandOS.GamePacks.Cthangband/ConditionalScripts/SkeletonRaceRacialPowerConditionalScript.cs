namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SkeletonRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(SkeletonRaceRacialPowerTest), true, 0)
    };
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.SkeletonRacialPowerScript) };
}