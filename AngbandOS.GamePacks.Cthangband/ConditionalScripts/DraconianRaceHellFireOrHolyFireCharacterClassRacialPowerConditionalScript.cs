namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceHellFireOrHolyFireCharacterClassRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(DraconianRaceHellFireOrHolyFireCharacterClassRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerHellFireOrHolyFireProjectileScriptWeightedRandom) };
}