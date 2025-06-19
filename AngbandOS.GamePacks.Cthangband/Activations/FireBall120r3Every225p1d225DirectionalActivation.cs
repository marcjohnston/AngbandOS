// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Shoot a fire ball that does 120 damage with a larger radius.
/// </summary>
[Serializable]
public class FireBall120r3Every225p1d225DirectionalActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows deep red...";

    public override string RechargeTimeRollExpression => "1d225+225";

    public override string ActivationCancellableScriptItemBindingKey => nameof(Fire120R3ProjectileScript);

    public override int Value => 1750;

    public override string Name => "Large fire ball (120)";

}
