// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Heal 1000 health and remove all bleeding.
/// </summary>
[Serializable]
public class Heal1000Every888Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows a bright white...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.Heal1000Script);

    public override string RechargeTimeRollExpression => "888";

    public override int Value => 15000;

    public override string Name => "Heal (1000)";

}