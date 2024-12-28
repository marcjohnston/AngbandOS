// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Shoot a 12-damage ball of poison
/// </summary>
[Serializable]
internal class StinkingCloud12Every1d4p4DirectionalActivation : DirectionalActivation
{
    private StinkingCloud12Every1d4p4DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} throbs deep green...";

    protected override string RechargeTimeRollExpression => "1d4+4";

    protected override string DirectionalActivationCancellableScriptBindingKey => nameof(StinkingCloud12Script);

    public override int Value => 300;

    public override string Name => "Stinking cloud (12) rad. 3";

}
