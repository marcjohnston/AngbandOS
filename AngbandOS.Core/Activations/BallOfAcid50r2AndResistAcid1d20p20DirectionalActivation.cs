// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class BallOfAcid50r2AndResistAcid1d20p20DirectionalActivation : Activation
{
    private BallOfAcid50r2AndResistAcid1d20p20DirectionalActivation(Game game) : base(game) { }

    protected override string RechargeTimeRollExpression => "1d50+50";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(BallOfAcid50r2AndResistAcid1d20p20Script);

    public override int Value => 1000;

    public override string Name => "Ball of acid and resist acid";

}

