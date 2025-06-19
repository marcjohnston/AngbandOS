namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CyclopsRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(CyclopsRaceRacialPowerTest), true, 0)
    };
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(Cyclops3xO2RacialPowerProjectileScript) };
}