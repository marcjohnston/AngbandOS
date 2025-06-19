// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Place a Yellow Sign.
/// </summary>
[Serializable]
public class RuneExploActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows a sickly yellow...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.YellowSignScript);

    public override string RechargeTimeRollExpression => "200";

    public override int Value => 4000;

    public override string Name => "Yellow Sign";

}
