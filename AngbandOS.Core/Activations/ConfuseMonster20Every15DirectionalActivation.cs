﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.DirectionalActivations;

/// <summary>
/// Confuse an opponent.
/// </summary>
[Serializable]
internal class ConfuseMonster20Every15DirectionalActivation : Activation
{
    private ConfuseMonster20Every15DirectionalActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows in scintillating colors...";

    protected override string RechargeTimeRollExpression => "15";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(OldConfuse20ProjectileScript);

    public override int Value => 500;

    public override string Name => "Confuse monster";

}
