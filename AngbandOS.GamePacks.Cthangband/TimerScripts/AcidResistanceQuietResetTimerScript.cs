namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidResistanceQuietResetTimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => null;
    public override bool Quiet => true;
    public override string TimerBindingKey => nameof(TimersEnum.AcidResistanceTimer);
}

