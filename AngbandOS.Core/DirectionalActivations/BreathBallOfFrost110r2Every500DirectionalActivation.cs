﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class BreathBallOfFrost110r2Every500DirectionalActivation : DirectionalActivation
{
    private BreathBallOfFrost110r2Every500DirectionalActivation(Game game) : base(game) { }

    public override string? PreActivationMessage => ""; // No message is displayed to the player.

    protected override string? PostAimingMessage => "You breathe frost.";

    protected override string RechargeTimeRollExpression => "1d450+450";

    protected override bool Activate(int direction)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), direction, 110, -2);
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Frost breath (110)";

}

