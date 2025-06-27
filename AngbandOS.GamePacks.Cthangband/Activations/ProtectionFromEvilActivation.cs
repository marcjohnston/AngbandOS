// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Give us protection from evil.
/// </summary>
[Serializable]
public class ProtectionFromEvilActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} lets out a shrill wail...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(ProtectionFromEvil3XP1d25TimerScript);

    public override string RechargeTimeRollExpression => "1d225+225";

    public override int Value => 5000;

    public override string Name => "Protect evil (dur level*3 + d25)";

}
