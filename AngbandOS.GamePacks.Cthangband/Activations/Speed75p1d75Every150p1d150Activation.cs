// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Give us temporary haste.
/// </summary>
[Serializable]
public class Speed75p1d75Every150p1d150Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "The {0} glows brightly...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.Speed75p1d75Script);

    public override string RechargeTimeRollExpression => "1d150+150";

    public override int Value => 20000;

    public override string Name => "Haste self (75+d75)";

}
