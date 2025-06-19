// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Summon a demon, with a 1-in-3 chance of it being hostile.
/// </summary>
[Serializable]
public class SummonFriendlyDemon2In3Activation : ActivationGameConfiguration
{

    public override string ActivationCancellableScriptItemBindingKey => nameof(Demon3xO2Pet2In3SummonWeightedRandom);

    public override string RechargeTimeRollExpression => "1d333+666";

    public override int Value => 20000;

    public override string Name => "Summon demon";

}
