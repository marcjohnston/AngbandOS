﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Give temporary telepathy.
/// </summary>
[Serializable]
public class TemporaryEsp20p1d30Every200Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "";

    public override string ActivationCancellableScriptItemBindingKey => nameof(Telepathy1d30p25TimerScript);

    public override string RechargeTimeRollExpression => "200";

    public override int Value => 1500;

    public override string Name => "Temporary ESP (25+d30)";

}
