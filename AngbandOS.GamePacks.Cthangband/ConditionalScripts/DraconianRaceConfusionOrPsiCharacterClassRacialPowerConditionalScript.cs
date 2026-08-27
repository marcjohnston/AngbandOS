namespace AngbandOS.GamePacks.Cthangband;

public class DraconianRaceConfusionOrPsiCharacterClassRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(DraconianRaceConfusionOrPsiCharacterClassRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerConfusionOrPsiProjectileScriptWeightedRandom) };
}