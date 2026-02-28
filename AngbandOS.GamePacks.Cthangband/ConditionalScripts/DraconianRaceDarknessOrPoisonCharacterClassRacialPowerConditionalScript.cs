namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceDarknessOrPoisonCharacterClassRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(DraconianRaceDarknessOrPoisonCharacterClassRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerDarknessOrPoisonProjectileScriptWeightedRandom) };
}