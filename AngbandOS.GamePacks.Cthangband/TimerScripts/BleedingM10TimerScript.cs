namespace AngbandOS.GamePacks.Cthangband;

public class BleedingM10TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "-10";
    public override string TimerBindingKey => nameof(TimersEnum.BleedingTimer);
}
