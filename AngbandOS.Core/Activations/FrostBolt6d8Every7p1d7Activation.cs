// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a frost bolt that does 6d8 damage.
/// </summary>
[Serializable]
internal class FrostBolt6d8Every7p1d7Activation : DirectionalActivation
{
    private FrostBolt6d8Every7p1d7Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} is covered in frost...";

    protected override string RechargeTimeRollExpression => "1d7+7";

    protected override bool Activate(int direction)
    {
        Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), direction, Game.DiceRoll(6, 8));
        return true;
    }

    public override int Value => 250;

    public override string Name => "Frost bolt (6d8)";

}
