// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Long range teleport.
/// </summary>
[Serializable]
public class Teleport100Every45Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} twists space around you...";

    public override string ActivationCancellableScriptItemBindingKey => nameof(TeleportSelf100TeleportSelfScript);

    public override string RechargeTimeRollExpression => "45";

    public override int Value => 2000;

    public override string Name => "Teleport (100)";

}
