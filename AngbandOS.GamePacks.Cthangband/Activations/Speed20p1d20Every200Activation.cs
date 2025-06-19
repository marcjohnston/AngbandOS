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
public class Speed20p1d20Every200Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "A wind swirls around your {0}...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.Speed20p1d20Script);

    public override string RechargeTimeRollExpression => "200";

    public override int Value => 16000;

    public override string Name => "Haste self (20+d20)";

}
