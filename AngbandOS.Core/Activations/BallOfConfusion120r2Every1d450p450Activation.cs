// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
internal class BallOfConfusion120r2Every1d450p450Activation : DirectionalActivation
{
    private BallOfConfusion120r2Every1d450p450Activation(Game game) : base(game) { }

    public override string? PreActivationMessage => "You breathe confusion.";
    public override int RechargeTime() => Game.DieRoll(450) + 450;

    protected override bool Activate(int direction)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ConfusionProjectile)), direction, 120, -2);
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Breathe confusion (120)";

    public override string Frequency => "450+d450";
}

