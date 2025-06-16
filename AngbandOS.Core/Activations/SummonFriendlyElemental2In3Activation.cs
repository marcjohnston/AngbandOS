// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Activations;

/// <summary>
/// Summon an elemental, with a 1-in-3 chance of it being hostile.
/// </summary>
[Serializable]
internal class SummonFriendlyElemental2In3Activation : Activation
{
    private SummonFriendlyElemental2In3Activation(Game game) : base(game) { }

    protected override string ActivationCancellableScriptItemBindingKey => nameof(Elemental3xD2SummonWeightedRandom);

    protected override string RechargeTimeRollExpression => "750";

    public override int Value => 15000;

    public override string Name => "Summon elemental";

}
