// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Give us extra haste for a long time.
/// </summary>
[Serializable]
public class XtraSpeedActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows brightly...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.XtraSpeedScript);

    public override string RechargeTimeRollExpression => "1d200+200";

    public override int Value => 25000;

    public override string Name => "Speed (75+d75)";

}
