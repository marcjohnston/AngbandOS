﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Turn an item to gold.
/// </summary>
[Serializable]
public class GetawayEvery35Activation : ActivationGameConfiguration
{

    
    public override string? PreActivationMessage => "Your {0} shimmers...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.GetawayScript);

    public override string RechargeTimeRollExpression => "35";

    public override int Value => 500;

    public override string Name => "A getaway";
}
