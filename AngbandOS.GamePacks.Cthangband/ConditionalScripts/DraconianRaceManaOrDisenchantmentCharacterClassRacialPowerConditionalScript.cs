namespace AngbandOS.GamePacks.Cthangband;

public class DraconianRaceManaOrDisenchantmentCharacterClassRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(DraconianRaceManaOrDisenchantmentCharacterClassRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerManaOrDisenchantmentProjectileScriptWeightedRandom) };
}