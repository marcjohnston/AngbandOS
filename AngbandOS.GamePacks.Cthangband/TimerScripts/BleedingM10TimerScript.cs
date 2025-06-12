namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BleedingM10TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "-10";
    public override string TimerBindingKey => nameof(TimersEnum.BleedingTimer);
}
