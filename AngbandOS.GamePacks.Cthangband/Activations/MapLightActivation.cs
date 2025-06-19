// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Map the local area.
/// </summary>
[Serializable]
public class MapLightActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} shines brightly...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.MapLightScript);

    public override string RechargeTimeRollExpression => "1d50+50";

    public override int Value => 500;

    public override string Name => "Light (dam 2d15) & map area";

}
