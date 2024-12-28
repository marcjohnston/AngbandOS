// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Drain up to 120 life from an opponent.
/// </summary>
[Serializable]
internal class DrainLife120Every400DirectionalActivation : DirectionalActivation
{
    private DrainLife120Every400DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows black...";

    protected override string RechargeTimeRollExpression => "400";

    protected override string DirectionalActivationCancellableScriptBindingKey => nameof(DrainLife120Script);

    public override int Value => 750;

    public override string Name => "Drain life (120)";

}
