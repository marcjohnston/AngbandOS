﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Heal 700 health and remove all bleeding.
/// </summary>
[Serializable]
internal class Heal700Every25Activation : Activation
{
    private Heal700Every25Activation(Game game) : base(game) { }
    public override int RandomChance => 25;

    public override string? PreActivationMessage => "Your {0} glows deep blue...";

    protected override bool OnActivate(Item item)
    {
        Game.MsgPrint("You feel a warm tingling inside...");
        Game.RestoreHealth(700);
        Game.BleedingTimer.ResetTimer();
        return true;
    }

    public override int RechargeTime() => 250;

    public override int Value => 10000;

    public override string Name => "Heal (700)";

    public override string Frequency => "250";
}