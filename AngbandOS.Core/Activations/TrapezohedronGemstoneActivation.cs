// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Activations;

/// <summary>
/// Word of Recall.
/// </summary>
[Serializable]
internal class TrapezohedronGemstoneActivation : Activation
{
    private TrapezohedronGemstoneActivation(Game game) : base(game) { }

    /// <summary>
    /// Returns a random chance of 0, because this activation only applies to a fixed artifact.
    /// </summary>
    
    public override string? PreActivationMessage => "";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(TrapezohedronGemstoneScript);

    protected override string RechargeTimeRollExpression => "1d20+20";

    public override int Value => 300;

    public override string Name => "Clairvoyance and recall, draining you";

}
