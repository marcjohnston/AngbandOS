// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a lightning storm that does 250 damage with a larger radius.
/// </summary>
[Serializable]
internal class LargeLightningBall250Every425p1d425Activation : DirectionalActivation
{
    private LargeLightningBall250Every425p1d425Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows deep blue...";

    public override int RechargeTime() => Game.RandomLessThan(425) + 425;

    protected override bool Activate(int direction)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ElecProjectile)), direction, 250, 3);
        return true;
    }

    public override int Value => 2000;
    public override string Name => "Large lightning ball (250)";
    public override string Frequency => "425+d425";
}
