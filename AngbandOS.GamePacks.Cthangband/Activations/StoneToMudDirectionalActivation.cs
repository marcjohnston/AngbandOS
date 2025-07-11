﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Rock to mud.
/// </summary>
[Serializable]
public class StoneToMudDirectionalActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} pulsates...";

    public override string RechargeTimeRollExpression => "5";

    public override string ActivationCancellableScriptItemBindingKey => nameof(WallToMud1d30p20ProjectileScript);

    public override int Value => 1000;

    public override string Name => "Stone to mud";

}
