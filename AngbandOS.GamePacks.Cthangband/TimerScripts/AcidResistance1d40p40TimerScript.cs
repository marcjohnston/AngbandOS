﻿namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidResistance1d40p40TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d40+40";
    public override string TimerBindingKey => nameof(TimersEnum.AcidResistanceTimer);
}

