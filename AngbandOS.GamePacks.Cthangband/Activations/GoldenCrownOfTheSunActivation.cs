// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Word of Recall.
/// </summary>
[Serializable]
public class GoldenCrownOfTheSunActivation : ActivationGameConfiguration
{

    /// <summary>
    /// Returns a random chance of 0, because this activation only applies to a fixed artifact.
    /// </summary>
    
    public override string? PreActivationMessage => "";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.GoldenCrownOfTheSunScript);

    public override string RechargeTimeRollExpression => "800";

    public override int Value => 7500;

    public override string Name => "Heal (700)";

}
