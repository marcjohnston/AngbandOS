// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Activate the Call Chaos spell.
/// </summary>
[Serializable]
public class CallChaosEvery350Activation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} glows in scintillating colors...";

    public override string RechargeTimeRollExpression => "350";

    public override string ActivationCancellableScriptItemBindingKey => nameof(CallChaosProjectileScriptWeightedRandom);

    public override int Value => 5000;

    public override string Name => "Call chaos";

}
