namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatOneRaceDreamingPowerRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(GreatOneRaceDreamingPowerRacialPowerTest), true, 0)
    };
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.GreatOneRaceDreamingPowerRacialPowerScript) };
}