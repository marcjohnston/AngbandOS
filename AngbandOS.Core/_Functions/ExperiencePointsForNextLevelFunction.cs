// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Functions;

/// <summary>
/// Represents an integer function that returns the amount of experience points that the player needs to gain to advance to the next experience level.
/// </summary>
[Serializable]
internal class ExperiencePointsForNextLevelFunction : IntFunction
{
    private ExperiencePointsForNextLevelFunction(Game game) : base(game) { } // This object is a singleton.
    public override int Value => (Constants.PlayerExp[Game.ExperienceLevel.IntValue - 1] * Game.ExperienceMultiplier.IntValue / 100) - Game.ExperiencePoints.IntValue;
    public override string[]? DependencyNames => new string[]
    {
        nameof(ExperienceLevelIntProperty),
        nameof(ExperienceMultiplierIntProperty),
        nameof(ExperiencePointsIntProperty)
    };
}