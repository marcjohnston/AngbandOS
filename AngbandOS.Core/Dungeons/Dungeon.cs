// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text.Json;

namespace AngbandOS.Core.Dungeons;

/// <summary>
/// A dungeon that the player can explore
/// </summary>
[Serializable]
internal abstract class Dungeon : IGetKey
{
    protected readonly Game Game;

    /// <summary>
    /// Create the dungeon
    /// </summary>
    protected Dungeon(Game game)
    {
        Game = game;
        Offset = BaseOffset;
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() 
    {
        if (BiasMonsterFilterName != null)
        {
            BiasMonsterFilter = Game.SingletonRepository.Get<MonsterFilter>(BiasMonsterFilterName);
        }

        List<DungeonGuardian> dungeonGuardianList = new List<DungeonGuardian>();
        if (DungeonGuardianNames != null)
        {
            foreach (string dungeonGuardianName in DungeonGuardianNames)
            {
                dungeonGuardianList.Add(Game.SingletonRepository.Get<DungeonGuardian>(dungeonGuardianName));
            }
        }
        DungeonGuardians = dungeonGuardianList.ToArray();
    }

    /// <summary>
    /// Returns the deepest level the player has achieved for Word of Recall.
    /// </summary>
    public int RecallLevel;

    /// <summary>
    /// Returns base offset (difficulty) for the dungeon.
    /// </summary>
    public abstract int BaseOffset { get; }

    /// <summary>
    /// Returns the name of the monster filter to be used for a bias for generating monsters; or null, if the dungeon has no
    /// biasness.  Returns null, by default.
    /// </summary>
    protected virtual string? BiasMonsterFilterName { get; } = null;

    /// <summary>
    /// The bias for monster generation in the dungeon
    /// </summary>
    public MonsterFilter? BiasMonsterFilter { get; private set; } = null;

    /// <summary>
    /// Returns the quests that are associated to this dungeon; or an empty array, if there are none.  This property is bound during
    /// the binding phase from the DungeonQuestDefinitions property.
    /// </summary>
    public DungeonGuardian[] DungeonGuardians { get; private set; }

    /// <summary>
    /// Returns all of the quests associated to the dungeon.
    /// </summary>
    protected virtual string[]? DungeonGuardianNames => null;

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
    /// The shortened name of the dungeon for display purposes
    /// </summary>
    public abstract string Shortname { get; }

    /// <summary>
    /// Returns true, if the dungeon is a tower; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool Tower => false;

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

    public int ActiveQuestCount()
    {
        int activeQuestCount = 0;
        for (int i = 0; i < Game.Quests.Count; i++)
        {
            if (Game.Quests[i].IsActive && Game.Quests[i].Dungeon == this)
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
        for (int i = 0; i < Game.Quests.Count; i++)
        {
            Quest q = Game.Quests[i];
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
    /// Randomize the actual offset (difficulty) of each dungeon around its base offset for some variability
    /// </summary>
    public void RandomiseOffset()
    {
        // Maximum offset is the dungeon's base offset or 10, whichever is less (but since we're
        // using 'less than', we add one to both values here)
        int range = Math.Min((BaseOffset + 1), 11);
        int offsetChange = Game.RandomLessThan(range);
        // Dungeons are equally likely to be more or less difficult
        if (Game.DieRoll(6) >= 4)
        {
            Offset = BaseOffset + offsetChange;
        }
        else
        {
            Offset = BaseOffset - offsetChange;
        }
    }

    public bool IsValid(DungeonGameConfiguration dungeonGameConfiguration)
    {
        if (dungeonGameConfiguration.Key == null || 
            dungeonGameConfiguration.BaseOffset == null || 
            dungeonGameConfiguration.MapSymbol == null || 
            dungeonGameConfiguration.MaxLevel == null || 
            dungeonGameConfiguration.Name == null || 
            dungeonGameConfiguration.Shortname == null || 
            dungeonGameConfiguration.Tower == null)
        {
            return false;
        }
        return true;
    }

    public string ToJson()
    {
        DungeonGameConfiguration dungeon = new()
        {
            Key = Key,
            BaseOffset = BaseOffset,
            BiasMonsterFilterName = BiasMonsterFilterName,
            DungeonGuardianNames = DungeonGuardianNames,
            MapSymbol = MapSymbol,
            MaxLevel = MaxLevel,
            Name = Name,
            Shortname = Shortname,
            Tower = Tower
        };
        return JsonSerializer.Serialize(dungeon, Game.GetJsonSerializerOptions());
    }
}