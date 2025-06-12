namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Bleeding5000TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "5000";
    public override string TimerBindingKey => nameof(TimersEnum.BleedingTimer);
}
