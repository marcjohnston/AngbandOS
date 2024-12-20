﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Shoot a lightning bolt that does 4d8 damage
/// </summary>
[Serializable]
internal class LightningBolt4d8Every6p1d6DirectionalActivation : DirectionalActivation
{
    private LightningBolt4d8Every6p1d6DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} is covered in sparks...";

    protected override string RechargeTimeRollExpression => "1d6+6";

    protected override bool Activate(int direction)
    {
        Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(ElecProjectile)), direction, Game.DiceRoll(4, 8));
        return true;
    }

    public override int Value => 250;

    public override string Name => "Lightning bolt (4d8)";

}
