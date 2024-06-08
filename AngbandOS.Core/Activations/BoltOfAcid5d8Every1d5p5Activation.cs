// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
internal class BoltOfAcid5d8Every1d5p5Activation : DirectionalActivation
{
    private BoltOfAcid5d8Every1d5p5Activation(Game game) : base(game) { }

    public override string? PreActivationMessage => "Your {0} are covered in acid...";
    protected override string RechargeTimeRollExpression => "1d5+5";
    protected override bool Activate(int direction)
    {
        Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), direction, base.Game.DiceRoll(5, 8));
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Acid bolt (5d8)";

    public override string Frequency => "5+d5";
}

