// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class GenericDungeon : Dungeon
{
    public GenericDungeon(Game game, DungeonGameConfiguration dungeonGameConfiguration) : base(game)
    {
        Key = dungeonGameConfiguration.Key ?? dungeonGameConfiguration.GetType().Name;
        BaseOffset = dungeonGameConfiguration.BaseOffset;
        BiasMonsterFilterName = dungeonGameConfiguration.BiasMonsterFilterName;
        DungeonGuardianNames = dungeonGameConfiguration.DungeonGuardianNames;
        MapSymbol = dungeonGameConfiguration.MapSymbol;
        MaxLevel = dungeonGameConfiguration.MaxLevel;
        Name = dungeonGameConfiguration.Name;
        Shortname = dungeonGameConfiguration.Shortname;
        Tower = dungeonGameConfiguration.Tower;
    }

    public override string Key { get; }

    /// <summary>
    /// Returns base offset (difficulty) for the dungeon.
    /// </summary>
    public override int BaseOffset { get; }

    /// <summary>
    /// Returns the name of the monster filter to be used for a bias for generating monsters; or null, if the dungeon has no
    /// biasness.  Returns null, by default.
    /// </summary>
    protected override string? BiasMonsterFilterName { get; } = null;

    /// <summary>
    /// Returns all of the quests associated to the dungeon.
    /// </summary>
    protected override string[]? DungeonGuardianNames { get; } = null;

    /// <summary>
    /// The symbol used for the dungeon on the wilderness map
    /// </summary>
    public override string MapSymbol { get; }

    /// <summary>
    /// The number of levels the dungeon has
    /// </summary>
    public override int MaxLevel { get; }

    /// <summary>
    /// The full name of the dungeon
    /// </summary>
    public override string Name { get; }

    /// <summary>
    /// The shortened name of the dungeon for display purposes
    /// </summary>
    public override string Shortname { get; }

    /// <summary>
    /// Returns true, if the dungeon is a tower; false, otherwise.  Returns false, by default.
    /// </summary>
    public override bool Tower { get; } = false;
}