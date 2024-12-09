// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class BoltOfElectricity4d8Every1d6p6DirectionalActivation : DirectionalActivation
{
    private BoltOfElectricity4d8Every1d6p6DirectionalActivation(Game game) : base(game) { }

    public override string? PreActivationMessage => "Your {0} are covered in sparks...";
    protected override string RechargeTimeRollExpression => "1d6+6";
    protected override bool Activate(int direction)
    {
        Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(ElecProjectile)), direction, base.Game.DiceRoll(4, 8));
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Lightning bolt (4d8)";

}

