// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Place an ElderSign.
/// </summary>
[Serializable]
public class RuneProtActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows light blue...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.ElderSignScript);

    public override string RechargeTimeRollExpression => "400";

    public override int Value => 10000;

    public override string Name => "Rune of protection";

}
