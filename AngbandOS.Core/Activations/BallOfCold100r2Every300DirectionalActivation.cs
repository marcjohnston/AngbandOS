// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Shoot a frost ball that does 100 damage.
/// </summary>
[Serializable]
internal class BallOfCold100r2Every300DirectionalActivation : Activation
{
    private BallOfCold100r2Every300DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows an intense blue...";

    protected override string RechargeTimeRollExpression => "300";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(Cold100r2ProjectileScript);

    public override int Value => 1250;
    public override string Name => "Ball of cold (100)";

}
