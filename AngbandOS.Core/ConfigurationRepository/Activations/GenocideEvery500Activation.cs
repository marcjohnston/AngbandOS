﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Carnage a chosen creature type.
/// </summary>
[Serializable]
internal class GenocideEvery500Activation : Activation
{
    private GenocideEvery500Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 33;

    public override string? PreActivationMessage => "Your {0} glows deep blue...";

    protected override bool OnActivate(Item item)
    {
        SaveGame.RunScript(nameof(GenocideScript));
        return true;
    }

    public override int RechargeTime() => 500;

    public override int Value => 10000;

    public override string Name => "Carnage";

    public override string Frequency => "500";
}