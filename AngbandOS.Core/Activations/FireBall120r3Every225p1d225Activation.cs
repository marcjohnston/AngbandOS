// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a fire ball that does 120 damage with a larger radius.
/// </summary>
[Serializable]
internal class FireBall120r3Every225p1d225Activation : DirectionalActivation
{
    private FireBall120r3Every225p1d225Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows deep red...";

    protected override string RechargeTimeRollExpression => "1d225+225";

    protected override bool Activate(int direction)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), direction, 120, 3);
        return true;
    }

    public override int Value => 1750;

    public override string Name => "Fire ball (120)";

}
