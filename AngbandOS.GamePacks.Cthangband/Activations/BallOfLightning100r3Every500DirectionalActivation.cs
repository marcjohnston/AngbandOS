﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Shoot a lightning storm that does 100 damage with a larger radius.
/// </summary>
[Serializable]
public class BallOfLightning100r3Every500DirectionalActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} crackles with electricity...";

    public override string RechargeTimeRollExpression => "500";

    public override string ActivationCancellableScriptItemBindingKey => nameof(Electricity100r3ProjectileScript);

    public override int Value => 1500;
    public override string Name => "Ball of lightning (100)";

}
