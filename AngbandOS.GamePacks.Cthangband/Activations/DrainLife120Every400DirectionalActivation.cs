// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Drain up to 120 life from an opponent.
/// </summary>
[Serializable]
public class DrainLife120Every400DirectionalActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows black...";

    public override string RechargeTimeRollExpression => "400";

    public override string ActivationCancellableScriptItemBindingKey => nameof(OldDrainLife120ProjectileScript);

    public override int Value => 750;

    public override string Name => "Drain life (120)";

}
