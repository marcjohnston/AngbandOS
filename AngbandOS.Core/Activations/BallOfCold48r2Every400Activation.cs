// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a frost ball that does 48 damage.
/// </summary>
[Serializable]
internal class BallOfCold48r2Every400Activation : DirectionalActivation
{
    private BallOfCold48r2Every400Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} is covered in frost...";

    public override int RechargeTime() => 400;

    protected override bool Activate(int direction)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), direction, 48, 2);
        return true;
    }

    public override int Value => 750;
    public override string Name => "Ball of cold (48)";

    public override string Frequency => "400";
}
