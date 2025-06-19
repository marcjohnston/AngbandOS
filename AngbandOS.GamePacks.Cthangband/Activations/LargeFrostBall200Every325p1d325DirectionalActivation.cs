// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Shoot a frost ball that does 200 damage with a larger radius.
/// </summary>
[Serializable]
public class LargeFrostBall200Every325p1d325DirectionalActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows bright white...";

    public override string RechargeTimeRollExpression => "1d325+325";

    public override string ActivationCancellableScriptItemBindingKey => nameof(Cold200r3ProjectileScript);

    public override int Value => 2500;
    public override string Name => "Large frost ball (200)";

}
