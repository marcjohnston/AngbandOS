﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Activations;

/// <summary>
/// Fill us up.
/// </summary>
[Serializable]
internal class SatiateActivation : Activation
{
    private SatiateActivation(Game game) : base(game) { }

    protected override string ActivationCancellableScriptItemBindingKey => nameof(SatiateScript);

    protected override string RechargeTimeRollExpression => "200";

    public override int Value => 2000;

    public override string Name => "Satisfy hunger";

}
