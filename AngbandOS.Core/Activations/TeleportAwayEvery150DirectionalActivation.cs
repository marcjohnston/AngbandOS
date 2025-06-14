﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class TeleportAwayEvery150DirectionalActivation : Activation
{
    private TeleportAwayEvery150DirectionalActivation(Game game) : base(game) { }

    public override string? PreActivationMessage => "Your {0} glows deep red...";
    protected override string RechargeTimeRollExpression => "150";
    protected override string ActivationCancellableScriptItemBindingKey => nameof(TeleportAwayAll1xProjectileScript);

    public override int Value => 5000;

    public override string Name => "Teleport away";

}

