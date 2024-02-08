// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PersistConfigurationScript : Script, IScript
{
    private PersistConfigurationScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (SaveGame.CorePersistentStorage == null)
        {
            SaveGame.MsgPrint("No persistance interface was provided to save the configuration.");
            return;
        }

        try
        {
            Persist<Shopkeeper>(SaveGame.CorePersistentStorage, SaveGame.SingletonRepository.Shopkeepers, nameof(Shopkeeper));
            Persist<Town>(SaveGame.CorePersistentStorage, SaveGame.SingletonRepository.Towns, nameof(Town));
            Persist<GameCommand>(SaveGame.CorePersistentStorage, SaveGame.SingletonRepository.GameCommands, nameof(GameCommand));
            Persist<StoreCommand>(SaveGame.CorePersistentStorage, SaveGame.SingletonRepository.StoreCommands, nameof(StoreCommand));
            Persist<HelpGroup>(SaveGame.CorePersistentStorage, SaveGame.SingletonRepository.HelpGroups, nameof(HelpGroup));
            Persist<MonsterRace>(SaveGame.CorePersistentStorage, SaveGame.SingletonRepository.MonsterRaces, nameof(MonsterRace));
            Persist<Symbol>(SaveGame.CorePersistentStorage, SaveGame.SingletonRepository.Symbols, nameof(Symbol));
            Persist<Vault>(SaveGame.CorePersistentStorage, SaveGame.SingletonRepository.Vaults, nameof(Vault));
            Persist<DungeonGuardian>(SaveGame.CorePersistentStorage, SaveGame.SingletonRepository.DungeonGuardians, nameof(DungeonGuardian));
            Persist<Dungeon>(SaveGame.CorePersistentStorage, SaveGame.SingletonRepository.Dungeons, nameof(Dungeon));
        }
        catch (NotImplementedException)
        {
            SaveGame.MsgPrint("The persistance interface does not support entity persistance.");
            return;
        }
        catch
        {
            SaveGame.MsgPrint("The persistance interface failed to save the configuration.");
            return;
        }
    }

    /// <summary>
    /// Persist the entities to the core persistent storage medium.  This method is only being used to generate database entities from objects.
    /// </summary>
    /// <param name="corePersistentStorage"></param>
    private void Persist<T>(ICorePersistentStorage corePersistentStorage, RepositoryCollection<T> repository, string name) where T : IToJson
    {
        // Check to see if there is a name.  If not, then the persist isn't enabled for this repository.
        if (name != null)
        {
            List<string> jsonEntityList = new();
            foreach (T item in repository)
            {
                string serializedEntity = item.ToJson();
                if (serializedEntity == null)
                {
                    throw new Exception("Entity did not serialize.");
                }
                jsonEntityList.Add(serializedEntity);
            }
            corePersistentStorage.PersistEntities(name, jsonEntityList.ToArray());
        }
    }
}
