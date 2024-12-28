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
internal class RecallActivation : Activation
{
    private RecallActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows soft white...";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(ToggleRecallScript);

    protected override string RechargeTimeRollExpression => "200";

    public override int Value => 7500;

    public override string Name => "Word of recall";

}
