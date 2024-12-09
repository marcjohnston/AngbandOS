// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Shoot a 'magic missile' cone that does 300 damage.
/// </summary>
[Serializable]
internal class ElementalBreath300r4Every500DirectionalActivation : DirectionalActivation
{
    private ElementalBreath300r4Every500DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => ""; // No message is displayed to the player.

    protected override string? PostAimingMessage => "You breathe the elements.";

    protected override string RechargeTimeRollExpression => "500";

    protected override bool Activate(int direction)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)), direction, 300, -4);
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Elemental breath (300)";

}
