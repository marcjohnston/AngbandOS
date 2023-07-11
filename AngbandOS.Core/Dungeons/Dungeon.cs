// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

/// <summary>
/// A dungeon that the player can explore
/// </summary>
[Serializable]
internal abstract class Dungeon
{
    /// <summary>
    /// Returns the deepest level the player has achieved for Word of Recall.
    /// </summary>
    public int RecallLevel;

    /// <summary>
    /// Returns base offset (difficulty) for the dungeon.
    /// </summary>
    public abstract int BaseOffset { get; }

    /// <summary>
    /// The bias for monster generation in the dungeon
    /// </summary>
    public virtual MonsterSelector? Bias => null;

    /// <summary>
    /// The race of the first fixed quest monster
    /// </summary>
    public virtual string FirstGuardian => ""; // TODO: Needs to be nullable Monster

    /// <summary>
    /// The level of the first fixed quest
    /// </summary>
    public virtual int FirstLevel => 0; // TODO: Should belong to first guardian as a separate object

    /// <summary>
    /// The symbol used for the dungeon on the wilderness map
    /// </summary>
    public abstract string MapSymbol { get; }

    /// <summary>
    /// The number of levels the dungeon has
    /// </summary>
    public abstract int MaxLevel { get; }

    /// <summary>
    /// The full name of the dungeon
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// The race of the second fixed quest monster
    /// </summary>
    public virtual string SecondGuardian => ""; // TODO: Needs to be a nullable monster

    /// <summary>
    /// The level of the second fixed quest
    /// </summary>
    public virtual int SecondLevel => 0; // TODO: Should belong to first guardian as a separate object

    /// <summary>
    /// The shortened name of the dungeon for display purposes
    /// </summary>
    public abstract string Shortname { get; }

    /// <summary>
    /// Returns true, if the dungeon is a tower; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool Tower => false;

    /// <summary>
    /// The index of the dungeon in the dungeon list
    /// </summary>
    public int Index;

    /// <summary>
    /// Whether or not the player knows the depth of the dungeon
    /// </summary>
    public bool KnownDepth = false;

    /// <summary>
    /// Whether or not the player knows the offset (difficulty) of the dungeon
    /// </summary>
    public bool KnownOffset = false;

    /// <summary>
    /// The actual offset (difficulty) of the dungeon
    /// </summary>
    public int Offset;

    /// <summary>
    /// Whether or not the player has visited the dungeon
    /// </summary>
    public bool Visited = false;

    /// <summary>
    /// The X coordinate of the dungeon on the island
    /// </summary>
    public int X = 0;

    /// <summary>
    /// The Y coordinate of the dungeon on the island
    /// </summary>
    public int Y = 0;

    protected readonly SaveGame SaveGame;
    public int ActiveQuestCount()
    {
        int activeQuestCount = 0;
        for (int i = 0; i < SaveGame.Quests.Count; i++)
        {
            if (SaveGame.Quests[i].IsActive && SaveGame.Quests[i].Dungeon == this)
            {
                activeQuestCount++;
            }
        }
        return activeQuestCount;
    }

    public int FirstQuest()
    {
        int lev = -1;
        int first = -1;
        for (int i = 0; i < SaveGame.Quests.Count; i++)
        {
            Quest q = SaveGame.Quests[i];
            if (q.Level > 0 && q.Dungeon == this)
            {
                if (first == -1 || q.Level < lev)
                {
                    first = i;
                    lev = q.Level;
                }
            }
        }
        return first;
    }

    /// <summary>
    /// Create the dungeon
    /// </summary>
    protected Dungeon(SaveGame saveGame)
    {
        SaveGame = saveGame;
        Offset = BaseOffset;
    }

    /// <summary>
    /// Randomize the actual offset (difficulty) of each dungeon around its base offset for some variability
    /// </summary>
    public void RandomiseOffset()
    {
        // Maximum offset is the dungeon's base offset or 10, whichever is less (but since we're
        // using 'less than', we add one to both values here)
        int range = Math.Min((BaseOffset + 1), 11);
        int offsetChange = Program.Rng.RandomLessThan(range);
        // Dungeons are equally likely to be more or less difficult
        if (Program.Rng.DieRoll(6) >= 4)
        {
            Offset = BaseOffset + offsetChange;
        }
        else
        {
            Offset = BaseOffset - offsetChange;
        }
    }
}