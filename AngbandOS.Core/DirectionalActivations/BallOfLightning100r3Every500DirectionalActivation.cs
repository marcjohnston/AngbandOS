// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Shoot a lightning storm that does 100 damage with a larger radius.
/// </summary>
[Serializable]
internal class BallOfLightning100r3Every500DirectionalActivation : DirectionalActivation
{
    private BallOfLightning100r3Every500DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} crackles with electricity...";

    protected override string RechargeTimeRollExpression => "500";

    protected override string DirectionalActivationCancellableScriptBindingKey => nameof(BallOfLightning100r3Script);

    public override int Value => 1500;
    public override string Name => "Ball of lightning (100)";

}
