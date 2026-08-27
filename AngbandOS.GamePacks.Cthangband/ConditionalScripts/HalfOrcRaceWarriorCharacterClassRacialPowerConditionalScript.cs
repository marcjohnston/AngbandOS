namespace AngbandOS.GamePacks.Cthangband;

public class HalfOrcRaceWarriorCharacterClassRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(HalfOrcRaceWarriorCharacterClassRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HalfOrcRacialPowerScript) };
}