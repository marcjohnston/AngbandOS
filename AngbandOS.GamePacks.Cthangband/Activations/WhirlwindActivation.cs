// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Make a physical attack against each adjacent monster.
/// </summary>
[Serializable]
public class WhirlwindActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "";  // There is no message for this artifact power.

    public override string RechargeTimeRollExpression => "250";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.WhirlwindScript);

    public override int Value => 7500;

    public override string Name => "Whirlwind attack";

}
