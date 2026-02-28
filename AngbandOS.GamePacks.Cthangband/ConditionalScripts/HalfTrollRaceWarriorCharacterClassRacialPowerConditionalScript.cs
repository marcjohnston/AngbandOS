namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfTrollRaceWarriorCharacterClassRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(HalfTrollRaceWarriorCharacterClassRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HalfTrollRacialPowerScript) };
}