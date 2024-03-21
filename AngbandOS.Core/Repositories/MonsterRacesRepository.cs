// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class MonsterRacesRepository : DictionaryRepository<MonsterRace>
{
    public MonsterRacesRepository(Game game) : base(game) { }

    public override void Load()
    {
        if (Game.Configuration.StoreCommands == null)
        {
            // Monster races must be loaded in a sorted order for the player birth quests to not hang.
            Add(LoadTypesFromAssembly<MonsterRace>().OrderBy(_monsterRace => _monsterRace.LevelFound));
        }
        else
        {
            foreach (MonsterRaceDefinition mosterRaceDefinition in Game.Configuration.MonsterRaces.OrderBy(_monsterRace => _monsterRace.LevelFound))
            {
                Add(new GenericMonsterRace(Game, mosterRaceDefinition));
            }
        }
    }

    /// <summary>
    /// Process the bind event for this repository.  Monsters need an additional step to identify their index.
    /// </summary>
    public override void Bind()
    {
        base.Bind();
        // We need to initialize the monster race indexes.
        for (int i = 0; i < Count; i++)
        {
            MonsterRace monsterRace = this[i];
            monsterRace.Index = i;
        }
    }
}