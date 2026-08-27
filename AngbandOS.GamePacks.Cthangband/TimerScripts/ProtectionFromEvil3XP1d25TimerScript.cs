namespace AngbandOS.GamePacks.Cthangband;

public class ProtectionFromEvil3XP1d25TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "3*X+1d25";
    public override string TimerBindingKey => nameof(TimersEnum.ProtectionFromEvilTimer);
}
