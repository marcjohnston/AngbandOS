﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Restore lost experience.
/// </summary>
[Serializable]
internal class RestLifeActivation : Activation
{
    private RestLifeActivation(Game game) : base(game) { }
    public override int RandomChance => 66;

    public override string? PreActivationMessage => "Your {0} glows a deep red...";

    protected override bool OnActivate(Item item)
    {
        Game.RunScript(nameof(RestoreLevelScript));
        return true;
    }

    public override int RechargeTime() => 450;

    public override int Value => 7500;

    public override string Name => "Restore life levels";

    public override string Frequency => "450";
}