// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Light the area.
/// </summary>
[Serializable]
public class LightActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} swells with clear light...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.LightAreaRadius3Damage2d15Script);

    public override string RechargeTimeRollExpression => "1d10+10";

    public override int Value => 150;

    public override string Name => "Light area (2d15)";

}
