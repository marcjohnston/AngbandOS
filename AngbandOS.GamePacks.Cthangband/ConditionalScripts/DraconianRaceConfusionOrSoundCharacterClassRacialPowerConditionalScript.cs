namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceConfusionOrSoundCharacterClassRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(DraconianRaceConfusionOrSoundCharacterClassRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerConfusionOrSoundProjectileScriptWeightedRandom) };
}