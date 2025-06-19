// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Cause an earthquake around the player.
/// </summary>
[Serializable]
public class QuakeActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "";

    public override string RechargeTimeRollExpression => "50";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.QuakeScript);

    public override int Value => 600;

    public override string Name => "Earthquake (rad 10)";

}
