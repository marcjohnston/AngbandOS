// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Heal 700 health and remove all bleeding.
/// </summary>
[Serializable]
public class Heal700Every25Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows deep blue...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.Heal700Script);

    public override string RechargeTimeRollExpression => "250";

    public override int Value => 10000;

    public override string Name => "Heal (700)";

}
