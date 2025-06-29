﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Shoot a shard ball for 120 + level damage.
/// </summary>
[Serializable]
public class ShardBallDirectionalActivation : ActivationGameConfiguration
{
    
    public override string RechargeTimeRollExpression => "400";

    public override string ActivationCancellableScriptItemBindingKey => nameof(Shard1xp120r2ProjectileScript);

    public override int Value => 5000;

    public override string Name => "Shard ball (120+level)";

}
