// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Heal 30 health and remove fear.
/// </summary>
[Serializable]
public class RemoveFearAndHeal30Every10Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.RemoveFearAndHeal30Script);

    public override string RechargeTimeRollExpression => "10";

    public override int Value => 500;

    public override string Name => "Remove fear & heal 30 hp";

}
