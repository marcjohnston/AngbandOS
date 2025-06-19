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
public class StarBall150Every1000p1d325DirectionalActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} is surrounded by lightning...";

    public override string RechargeTimeRollExpression => "1000";

    public override string ActivationCancellableScriptItemBindingKey => nameof(ElectricityAll150r3ProjectileScript);

    public override int Value => 8000;
    public override string Name => "Star ball (150)";

}
