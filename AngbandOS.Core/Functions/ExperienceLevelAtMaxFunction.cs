
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

/// <summary>
/// Represents a function that returns true, when the experience level of the player has reached the maximum attainable level for the game; false, otherwise.
/// </summary>
[Serializable]
internal class ExperienceLevelAtMaxFunction : BoolFunction
{
    private ExperienceLevelAtMaxFunction(Game game) : base(game) { }
    public override bool Value => Game.ExperienceLevel.Value >= Constants.PyMaxLevel;

    public override string[]? DependencyNames => new string[]
    {
        nameof(ExperienceLevelIntProperty)
    };
}

