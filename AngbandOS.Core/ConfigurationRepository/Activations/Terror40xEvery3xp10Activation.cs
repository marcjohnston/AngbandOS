﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Scare monsters with a 40+level strength.
/// </summary>
[Serializable]
internal class Terror40xEvery3xp10Activation : Activation
{
    private Terror40xEvery3xp10Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 75;

    public override int RechargeTime() => 3 * (SaveGame.ExperienceLevel + 10);
    public override string? PreActivationMessage => "rays of fear in every direction";
    protected override bool OnActivate(Item item)
    {
        SaveGame.TurnMonsters(40 + SaveGame.ExperienceLevel);
        return true;
    }

    public override int Value => 2500;

    public override string Name => "Terror (40p1x)";

    public override string Frequency => "3 * (1x+10)";
}