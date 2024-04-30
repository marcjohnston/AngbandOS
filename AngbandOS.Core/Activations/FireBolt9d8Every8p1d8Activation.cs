// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a fire bolt that does 9d8 damage.
/// </summary>
[Serializable]
internal class FireBolt9d8Every8p1d8Activation : DirectionalActivation
{
    private FireBolt9d8Every8p1d8Activation(Game game) : base(game) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "Your {0} is covered in fire...";

    public override int RechargeTime() => Game.RandomLessThan(8) + 8;

    protected override bool Activate(int direction)
    {
        Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), direction, Game.DiceRoll(9, 8));
        return true;
    }

    public override int Value => 250;

    public override string Name => "Fire bolt (9d8)";

    public override string Frequency => "8+d8";
}
