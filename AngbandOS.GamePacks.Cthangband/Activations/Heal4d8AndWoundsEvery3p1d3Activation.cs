// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Heal 4d8 health and reduce bleeding.
/// </summary>
[Serializable]
public class Heal4d8AndWoundsEvery3p1d3Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} radiates deep purple...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.Heal4d8AndWoundsScript);

    public override string RechargeTimeRollExpression => "1d3+3";

    public override int Value => 750;

    public override string Name => "Heal 4d8 & wounds";

}
