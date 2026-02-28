namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceConfusionOrPsiCharacterClassRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(DraconianRaceConfusionOrPsiCharacterClassRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerConfusionOrPsiProjectileScriptWeightedRandom) };
}