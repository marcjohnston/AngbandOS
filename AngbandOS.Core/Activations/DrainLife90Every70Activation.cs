// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Drain up to 100 life from an opponent.  This particular drain life is unique, in that, if the power doesn't affect a monster, it doesn't need to be recharged.
/// </summary>
[Serializable]
internal class DrainLife90Every70Activation : DirectionalActivation
{
    private DrainLife90Every70Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows white...";

    protected override string RechargeTimeRollExpression => "70";

    protected override bool Activate(int direction)
    {
        Game.DrainLife(direction, 90);
        return true;
    }

    public override int Value => 500;

    public override string Name => "Drain life (90)";

    public override string Frequency => "70";
}
