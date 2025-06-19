// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Shoot a 'magic missile' cone that does 300 damage.
/// </summary>
[Serializable]
public class ElementalBreath300r4Every500DirectionalActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => ""; // No message is displayed to the player.

    public override string RechargeTimeRollExpression => "500";

    public override string ActivationCancellableScriptItemBindingKey => nameof(Missile300rm4ProjectileScript);

    public override int Value => 5000;

    public override string Name => "Elemental breath (300)";

}
