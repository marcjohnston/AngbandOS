// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

[Serializable]
internal class ExperiencePointsForNextLevelFunction : IntFunction
{
    private ExperiencePointsForNextLevelFunction(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override int Value => ((Constants.PlayerExp[SaveGame.ExperienceLevel.Value - 1] * SaveGame.ExperienceMultiplier.Value / 100) - SaveGame.ExperiencePoints.Value);
    public override string[]? DependencyNames => new string[]
    {
        nameof(ExperienceLevelIntProperty),
        nameof(ExperienceMultiplierIntProperty),
        nameof(ExperiencePointsIntProperty)
    };
}