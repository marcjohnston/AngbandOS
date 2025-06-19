// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Shoot a 12-damage ball of poison
/// </summary>
[Serializable]
public class StinkingCloud12Every1d4p4DirectionalActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} throbs deep green...";

    public override string RechargeTimeRollExpression => "1d4+4";

    public override string ActivationCancellableScriptItemBindingKey => nameof(Poison12r3ProjectileScript);

    public override int Value => 300;

    public override string Name => "Stinking cloud (12) rad. 3";

}
