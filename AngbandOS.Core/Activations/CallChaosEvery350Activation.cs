// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Activate the Call Chaos spell.
/// </summary>
[Serializable]
internal class CallChaosEvery350Activation : Activation
{
    private CallChaosEvery350Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows in scintillating colors...";

    protected override string RechargeTimeRollExpression => "350";

    protected override bool OnActivate(Item item)
    {
        return Game.RunCancellableScript(nameof(CallChaosCancellableScript));
    }

    public override int Value => 5000;

    public override string Name => "Call chaos";

}
