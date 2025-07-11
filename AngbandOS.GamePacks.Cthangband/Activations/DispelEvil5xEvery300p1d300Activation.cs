﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Dispel evil with a strength of x5.
/// </summary>
[Serializable]
public class DispelEvil5xEvery300p1d300Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} floods the area with goodness...";

    public override string RechargeTimeRollExpression => "1d300+300";

    public override string ActivationCancellableScriptItemBindingKey => nameof(DispelEvilAtLos5xProjectileScript);

    public override int Value => 4000;

    public override string Name => "Dispel evil (x5)";

}
