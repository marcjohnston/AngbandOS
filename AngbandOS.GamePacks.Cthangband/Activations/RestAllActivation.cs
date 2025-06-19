// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Restore all ability drain and lost experience.
/// </summary>
[Serializable]
public class RestAllActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows a deep green...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.RestAllScript);

    public override string RechargeTimeRollExpression => "750";

    public override int Value => 15000;

    public override string Name => "Restore stats and life levels";

}
