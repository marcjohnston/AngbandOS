namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SeeInvisibility24P1d24TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "24+1d24";
    public override string TimerBindingKey => nameof(TimersEnum.SeeInvisibilityTimer);
}
