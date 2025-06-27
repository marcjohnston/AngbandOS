// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Give us temporary invulnerabliity.
/// </summary>
[Serializable]
public class InvulnActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "";

    public override string ActivationCancellableScriptItemBindingKey => nameof(Invulnerability1d8p8TimerScript);

    public override string RechargeTimeRollExpression => "1000";

    public override int Value => 25000;

    public override string Name => "Invulnerability (8+d8)";

}
