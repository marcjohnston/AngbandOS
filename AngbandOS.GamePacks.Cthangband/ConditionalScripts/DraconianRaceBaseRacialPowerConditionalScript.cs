namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceBaseRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(DraconianRaceBaseRacialPowerConditional); 
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerFireOrColdProjectileScriptWeightedRandom) };
}