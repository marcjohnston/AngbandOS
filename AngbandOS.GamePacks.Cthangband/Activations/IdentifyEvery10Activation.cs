// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Identify an item.
/// </summary>
[Serializable]
public class IdentifyEvery10Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows yellow...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.IdentifyItemScript);

    public override string RechargeTimeRollExpression => "10";

    public override int Value => 1250;

    public override string Name => "Identify";

}
