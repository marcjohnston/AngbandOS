﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Place an ElderSign.
/// </summary>
[Serializable]
internal class RuneProtActivation : Activation
{
    private RuneProtActivation(Game game) : base(game) { }
    public override int RandomChance => 25;

    public override string? PreActivationMessage => "Your {0} glows light blue...";

    protected override bool OnActivate(Item item)
    {
        Game.RunScript(nameof(ElderSignScript));
        return true;
    }

    public override int RechargeTime() => 400;

    public override int Value => 10000;

    public override string Name => "Rune of protection";

    public override string Frequency => "400";
}