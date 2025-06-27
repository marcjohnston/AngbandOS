namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Infravision100P1d100TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "100+1d1100";
    public override string TimerBindingKey => nameof(TimersEnum.InfravisionTimer);
}
