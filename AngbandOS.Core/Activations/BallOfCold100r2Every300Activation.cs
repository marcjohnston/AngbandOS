// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a frost ball that does 100 damage.
/// </summary>
[Serializable]
internal class BallOfCold100r2Every300Activation : DirectionalActivation
{
    private BallOfCold100r2Every300Activation(Game game) : base(game) { }
    public override int RandomChance => 0; // TODO: Confirm this artifact does not have a corresponding random chance.  It is only used with biased artifacts.

    public override string? PreActivationMessage => "Your {0} glows an intense blue...";

    public override int RechargeTime() => 300;

    protected override bool Activate(int direction)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), direction, 100, 2);
        return true;
    }

    public override int Value => 1250;
    public override string Name => "Ball of cold (100)";

    public override string Frequency => "300";
}
