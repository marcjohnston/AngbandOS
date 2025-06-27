namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ColdResistance10P1d10TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "10+1d10";
    public override string TimerBindingKey => nameof(TimersEnum.ColdResistanceTimer);
}
