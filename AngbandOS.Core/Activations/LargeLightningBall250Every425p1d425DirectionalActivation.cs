// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Shoot a lightning storm that does 250 damage with a larger radius.
/// </summary>
[Serializable]
internal class LargeLightningBall250Every425p1d425DirectionalActivation : Activation
{
    private LargeLightningBall250Every425p1d425DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows deep blue...";

    protected override string RechargeTimeRollExpression => "1d425+425";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(Electricity250r3ProjectileScript);

    public override int Value => 2000;
    public override string Name => "Large lightning ball (250)";
}
