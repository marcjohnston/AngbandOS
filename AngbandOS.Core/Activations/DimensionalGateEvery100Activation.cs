// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Activations;

/// <summary>
/// Short range teleport to a specific destination.
/// </summary>
[Serializable]
internal class DimensionalGateEvery100Activation : Activation
{
    private DimensionalGateEvery100Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "You open a dimensional gate. Choose a destination.";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(DimensionalGateScript);

    protected override string RechargeTimeRollExpression => "100";

    public override int Value => 10000;

    public override string Name => "Dimension gate";

}
