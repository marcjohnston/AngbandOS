namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Stoneskin30P1d20TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "30+1d20";
    public override string TimerBindingKey => nameof(TimersEnum.StoneskinTimer);
}
