namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GolemRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(GolemRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(Stoneskin30P1d20TimerScript) };
}