// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Charm multiple animals.
/// </summary>
[Serializable]
public class CharmAnimalEvery500Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "";

    public override string RechargeTimeRollExpression => "500";

    public override string ActivationCancellableScriptItemBindingKey => nameof(ControlAnimalAtLos2xProjectileScript);

    public override int Value => 12500;

    public override string Name => "Charm animal";

}
