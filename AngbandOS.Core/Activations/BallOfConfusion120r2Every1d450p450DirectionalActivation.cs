﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class BallOfConfusion120r2Every1d450p450DirectionalActivation : Activation
{
    private BallOfConfusion120r2Every1d450p450DirectionalActivation(Game game) : base(game) { }

    public override string? PreActivationMessage => "You breathe confusion.";
    protected override string RechargeTimeRollExpression => "1d450+450";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(Confusion120rm2ProjectileScript);

    public override int Value => 5000;

    public override string Name => "Breathe confusion (120)";

}

