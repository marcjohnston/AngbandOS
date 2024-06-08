// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a magic missile that does 2d6 damage
/// </summary>
[Serializable]
internal class MagicMissile2d6Every2Activation : DirectionalActivation
{
    private MagicMissile2d6Every2Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows extremely brightly...";

    public override int RechargeTime() => 2;

    protected override bool Activate(int direction)
    {
        Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)), direction, Game.DiceRoll(2, 6));
        return true;
    }

    public override int Value => 250;

    public override string Name => "Magic missile (2d6)";

    public override string Frequency => "2";
}
