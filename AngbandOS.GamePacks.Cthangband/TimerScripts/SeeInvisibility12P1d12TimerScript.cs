namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SeeInvisibility12P1d12TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "12+1d12";
    public override string TimerBindingKey => nameof(TimersEnum.SeeInvisibilityTimer);
}
