// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
internal class BallOfFire72r2Every400Activation : DirectionalActivation
{
    private BallOfFire72r2Every400Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows an intense red...";

    public override int RechargeTime() => 400;

    protected override bool Activate(int direction)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), direction, 72, 2);
        return true;
    }

    public override int Value => 1000;

    public override string Name => "Ball of fire (72)";

    public override string Frequency => "400";
}
