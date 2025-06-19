// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Give us temporary resistance to the basic elements.
/// </summary>
[Serializable]
public class ResistAll20p1d20Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows many colors...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.ResistAll20p1d20Script);

    public override string RechargeTimeRollExpression => "111";

    public override int Value => 5000;

    public override string Name => "Resist elements (40+d40)";

}
