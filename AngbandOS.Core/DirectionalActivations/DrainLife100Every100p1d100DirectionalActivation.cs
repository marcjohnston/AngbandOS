// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Drain up to 100 life from an opponent.  This particular drain life is unique, in that, if the power doesn't affect a monster, it doesn't need to be recharged.
/// </summary>
[Serializable]
internal class DrainLife100Every100p1d100DirectionalActivation : DirectionalActivation
{
    private DrainLife100Every100p1d100DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "You order Frakir to strangle your opponent.";

    protected override string RechargeTimeRollExpression => "1d100+100";

    protected override string DirectionalActivationCancellableScriptBindingKey => nameof(OldDrainLife100ProjectileScript);

    public override int Value => 500;

    public override string Name => "Drain life (100)";

}
