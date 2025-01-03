// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class BreatheLightningFrostAcidPoisonGasOrFire250r2Every1d225p225DirectionalActivation : Activation
{
    private BreatheLightningFrostAcidPoisonGasOrFire250r2Every1d225p225DirectionalActivation(Game game) : base(game) { }

    protected override string RechargeTimeRollExpression => "1d225+225";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(FireColdElectricityPoisonGasOrAcid220rm2ProjectileWeightedRandomScript);

    public override int Value => 5000;

    public override string Name => "Breathe multi-hued (250)";

}

