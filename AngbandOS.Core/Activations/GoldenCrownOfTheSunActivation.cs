﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Word of Recall.
/// </summary>
[Serializable]
internal class GoldenCrownOfTheSunActivation : Activation
{
    private GoldenCrownOfTheSunActivation(Game game) : base(game) { }

    /// <summary>
    /// Returns a random chance of 0, because this activation only applies to a fixed artifact.
    /// </summary>
    public override int RandomChance => 0;

    public override string? PreActivationMessage => "";

    protected override bool OnActivate(Item item)
    {
        Game.MsgPrint("Your crown glows deep yellow...");
        Game.MsgPrint("You feel a warm tingling inside...");
        Game.RestoreHealth(700);
        Game.BleedingTimer.ResetTimer();
        return true;
    }

    public override int RechargeTime() => 800;

    public override int Value => 7500;

    public override string Name => "Heal (700)";

    public override string Frequency => "250";
}