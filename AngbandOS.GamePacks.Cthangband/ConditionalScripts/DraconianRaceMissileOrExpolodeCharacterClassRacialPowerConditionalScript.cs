namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceMissileOrExpolodeCharacterClassRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(DraconianRaceMissileOrExpolodeCharacterClassRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerMissileOrExpolodeProjectileScriptWeightedRandom) };
}