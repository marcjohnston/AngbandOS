﻿namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Blessing1d24p12TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d24+12";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
