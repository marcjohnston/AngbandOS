﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Shoot a magic missile that does 2d6 damage
/// </summary>
[Serializable]
public class MagicMissile2d6Every2DirectionalActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows extremely brightly...";

    public override string RechargeTimeRollExpression => "2";

    public override string ActivationCancellableScriptItemBindingKey => nameof(Missile2d6ProjectileScript);

    public override int Value => 5000;

    public override string Name => "Magic missile (2d6)";
}
