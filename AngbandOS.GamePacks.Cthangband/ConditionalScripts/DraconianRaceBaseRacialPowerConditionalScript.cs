namespace AngbandOS.GamePacks.Cthangband;

public class DraconianRaceBaseRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(DraconianRaceBaseRacialPowerConditional); 
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerFireOrColdProjectileScriptWeightedRandom) };
}