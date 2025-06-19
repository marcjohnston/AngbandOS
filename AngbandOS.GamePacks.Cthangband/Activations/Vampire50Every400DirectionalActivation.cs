// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Drain up to 50 life from an opponent, and give it to the player.
/// </summary>
[Serializable]
public class Vampire50Every400DirectionalActivation : ActivationGameConfiguration
{
    
    public override string RechargeTimeRollExpression => "400";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.Vampire50Script);

    public override int Value => 1000;

    public override string Name => "Vampiric drain 3x (50)";

}
