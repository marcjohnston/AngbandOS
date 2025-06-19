namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceHellFireOrHolyFireCharacterClassRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(DraconianRaceRacialPowerTest), true, 0)
    };
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerHellFireOrHolyFireProjectileWeightedRandom) };
}