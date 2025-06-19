// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Summon an elemental, with a 1-in-3 chance of it being hostile.
/// </summary>
[Serializable]
public class SummonFriendlyElemental2In3Activation : ActivationGameConfiguration
{

    public override string ActivationCancellableScriptItemBindingKey => nameof(Elemental3xO2SummonWeightedRandom);

    public override string RechargeTimeRollExpression => "750";

    public override int Value => 15000;

    public override string Name => "Summon elemental";

}
