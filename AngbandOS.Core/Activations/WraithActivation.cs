﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give us temporary etherealness.
/// </summary>
[Serializable]
internal class WraithActivation : Activation
{
    private WraithActivation(Game game) : base(game) { }
    public override int RandomChance => 5;

    public override string? PreActivationMessage => "";

    protected override bool OnActivate(Item item)
    {
        Game.EtherealnessTimer.AddTimer(Game.DieRoll(Game.ExperienceLevel.Value));
        return true;
    }

    public override int RechargeTime() => 1000;

    public override int Value => 25000;

    public override string Name => "Wraith form (1d1x)";

    public override string Frequency => "1000";
}