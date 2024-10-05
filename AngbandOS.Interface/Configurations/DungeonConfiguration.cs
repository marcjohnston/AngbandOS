// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.Interface;

[Serializable]
public class DungeonConfiguration : IConfiguration
{
    public virtual string Key { get; set; }

    /// <summary>
    /// Returns base offset (difficulty) for the dungeon.
    /// </summary>
    public virtual int BaseOffset { get; set; }

    /// <summary>
    /// Returns the name of the monster filter to be used for a bias for generating monsters; or null, if the dungeon has no
    /// biasness.  Returns null, by default.
    /// </summary>
    public virtual string? BiasMonsterFilterName { get; set; } = null;

    /// <summary>
    /// Returns all of the quests associated to the dungeon.
    /// </summary>
    public virtual string[]? DungeonGuardianNames { get; set; } = null;

    /// <summary>
    /// The symbol used for the dungeon on the wilderness map
    /// </summary>
    public virtual string MapSymbol { get; set; }

    /// <summary>
    /// The number of levels the dungeon has
    /// </summary>
    public virtual int MaxLevel { get; set; }

    /// <summary>
    /// The full name of the dungeon
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// The shortened name of the dungeon for display purposes
    /// </summary>
    public virtual string Shortname { get; set; }

    /// <summary>
    /// Returns true, if the dungeon is a tower; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool Tower { get; set; } = false;

    public bool IsValid()
    {
        if (Key == null || BaseOffset == null || MapSymbol == null || MaxLevel == null || Name == null || Shortname == null || Tower == null)
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return Key;
    }
}