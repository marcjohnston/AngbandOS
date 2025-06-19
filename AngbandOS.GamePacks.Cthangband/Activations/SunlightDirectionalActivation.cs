// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Aim a line of light in a direction of the player's choice
/// </summary>
[Serializable]
public class SunlightDirectionalActivation : ActivationGameConfiguration
{

    public override string RechargeTimeRollExpression => "10";

    public override string ActivationCancellableScriptItemBindingKey => nameof(LightWeak0ProjectileScript);

    public override int Value => 250;

    public override string Name => "Beam of sunlight";

}