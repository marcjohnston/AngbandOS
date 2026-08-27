namespace AngbandOS.GamePacks.Cthangband;

public class HalfOgreRaceWarriorCharacterClassRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(HalfOgreRaceWarriorCharacterClassRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HalfOgreRacialPowerScript) };
}