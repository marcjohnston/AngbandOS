// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class BallOfAcid130r2Every1d450p450DirectionalActivation : DirectionalActivation
{
    private BallOfAcid130r2Every1d450p450DirectionalActivation(Game game) : base(game) { }

    public override string? PreActivationMessage => "You breathe acid.";
    protected override string RechargeTimeRollExpression => "1d450+450";

    protected override string DirectionalActivationCancellableScriptBindingKey => nameof(BallOfAcid130r2Script);

    public override int Value => 5000;

    public override string Name => "Breathe acid (130)";

}

