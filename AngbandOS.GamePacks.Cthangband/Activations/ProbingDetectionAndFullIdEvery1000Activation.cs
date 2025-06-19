// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Detect everything and do probing and identify an item fully.
/// </summary>
[Serializable]
public class ProbingDetectionAndFullIdEvery1000Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows brightly...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.ProbingDetectionAndFullIdScript);

    public override string RechargeTimeRollExpression => "1000";

    public override int Value => 12500;

    public override string Name => "Probing, detection and full id";

}
