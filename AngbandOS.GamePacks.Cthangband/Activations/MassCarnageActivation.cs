// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Mass carnage creatures near the player.
/// </summary>
[Serializable]
public class MassCarnageActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} lets out a long, shrill note...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.MassCarnageScript);

    public override string RechargeTimeRollExpression => "1000";

    public override int Value => 10000;

    public override string Name => "Mass carnage";

}
