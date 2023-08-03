// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal class MonsterRacesRepositoryCollection : DictionaryRepositoryCollection<MonsterRace>
{
    public MonsterRacesRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

    public override void Load()
    {
        // Monster races must be loaded in a sorted order for the player birth quests to not hang.
        Add(LoadTypesFromAssembly<MonsterRace>().OrderBy(_monsterRace => _monsterRace.LevelFound));
    }

    public override void Loaded()
    {
        // We need to initialize the monster race indexes.
        for (int i = 0; i < Count; i++)
        {
            MonsterRace monsterRace = this[i];
            monsterRace.Index = i;
        }
    }
}