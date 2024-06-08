// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
internal class BallOfFire50r2AndResistFire1d20p20Activation : DirectionalActivation
{
    private BallOfFire50r2AndResistFire1d20p20Activation(Game game) : base(game) { }

    protected override string RechargeTimeRollExpression => "1d50+50";

    protected override bool Activate(int direction)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), direction, 50, 2);
        Game.FireResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        return true;
    }

    public override int Value => 1000;

    public override string Name => "Ball of fire and resist fire";

    public override string Frequency => "50+d50";
}

