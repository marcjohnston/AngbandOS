﻿
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Functions;

/// <summary>
/// Represents a boolean value function that returns true, when the experience level of the player has reached the maximum attainable level for the game; false, otherwise.
/// </summary>
[Serializable]
internal class ExperienceLevelAtMaxBoolFunction : BoolFunction
{
    private ExperienceLevelAtMaxBoolFunction(Game game) : base(game) { }
    public override bool BoolValue => Game.ExperienceLevel.IntValue >= Constants.PyMaxLevel;

    public override string[]? DependencyNames => new string[]
    {
        nameof(ExperienceLevelIntProperty)
    };
}

