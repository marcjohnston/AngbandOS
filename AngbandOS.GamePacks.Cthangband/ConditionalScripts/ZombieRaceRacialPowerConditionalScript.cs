namespace AngbandOS.GamePacks.Cthangband;

public class ZombieRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(ZombieRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.ZombieRacialPowerScript) };
}