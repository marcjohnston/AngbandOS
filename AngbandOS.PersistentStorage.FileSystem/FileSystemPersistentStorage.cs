using AngbandOS.Core.Interface;
using System.Text.Json;

namespace AngbandOS.PersistentStorage
{
    public class FileSystemPersistentStorage : ICorePersistentStorage
    {
        private string SaveFilename;

        public FileSystemPersistentStorage(string saveFilename)
        {
            SaveFilename = saveFilename;
        }

        public bool GameExists()
        {
            return File.Exists(SaveFilename);
        }

        private bool IsValidName(string name)
        {
            foreach (char c in name.ToLower())
            {
                if (!"abcdefghijklmnopqrstuvwxyz0123456789._".Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
        public void PersistEntities(string repositoryName, KeyValuePair<string, string>[] jsonEntities)
        {
            if (!IsValidName(repositoryName))
            {
                throw new Exception($"The repository name {repositoryName} contains invalid characters.  Only a-zA-Z0-9_. characters are allows.");
            }
            string path = Path.GetDirectoryName(SaveFilename);
            string folderName = Path.Combine(path, repositoryName);
            bool directoryCreated = false;

            try
            {
                Directory.Delete(folderName, true);
            }
            catch (DirectoryNotFoundException)
            {
            }

            // Process a folder of entities.
            foreach (KeyValuePair<string, string> keyValuePair in jsonEntities)
            {
                string key = keyValuePair.Key;
                if (!IsValidName(key))
                {
                    throw new Exception($"The entity key name {key} contains invalid characters.  Only a-z, A-Z, 0-9, . characters are allows.");
                }

                // Check to see if there is any content to save.  Empty content will not be written to the disk.
                if (keyValuePair.Value.Length > 0)
                {
                    // Check to see if we need to create the folder.
                    if (!directoryCreated)
                    {
                        Directory.CreateDirectory(folderName);
                    }

                    // Write the file.
                    string subfolderPath = Path.Combine(folderName, key);
                    string subfolderFilename = $"{subfolderPath}.json";
                    File.WriteAllText(subfolderFilename, keyValuePair.Value);
                }
            }
        }

        public void PersistEntity(string repositoryName, string json)
        {
            string path = Path.GetDirectoryName(SaveFilename);
            string folderName = Path.Combine(path, repositoryName);
            string filename = $"{folderName}.json";

            try
            {
                File.Delete(filename);
            }
            catch (FileNotFoundException)
            {
            }

            // Write the .json file for the null key values.
            if (json.Length > 0)
            {
                File.WriteAllText(filename, json);
            }
        }

        public string[] RetrieveEntities(string repositoryName)
        {
            string path = Path.GetDirectoryName(SaveFilename);
            string folderName = Path.Combine(path, repositoryName);
            try
            {
                string[] folderFiles = Directory.GetFiles(folderName);
                List<string> entities = new List<string>();
                foreach (string filename in folderFiles)
                {
                    string json = File.ReadAllText(Path.Combine(folderName, filename));
                    entities.Add(json);
                }
                return entities.ToArray();
            }
            catch (DirectoryNotFoundException)
            {
                return new string[] { };
            }
        }

        public string? RetrieveEntity(string repositoryName)
        {
            string path = Path.GetDirectoryName(SaveFilename);
            string folderName = Path.Combine(path, repositoryName);
            string filename = $"{folderName}.json";
            try
            {
                string json = File.ReadAllText(filename);
                return json;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        public byte[]? ReadGame()
        {
            byte[]? data = null;
            try
            {
                data = File.ReadAllBytes(SaveFilename);
            }
            catch (Exception)
            {
            }
            return data;
        }

        public bool WriteGame(GameDetails gameDetails, byte[] value)
        {
            File.WriteAllBytes(SaveFilename, value);
            return true;
        }

        public bool PersistGameConfiguration(GameConfiguration gameConfiguration, string configurationName, bool overwrite)
        {
            throw new NotImplementedException();
        }

        private TConfiguration[] LoadEntities<TConfiguration>(string repositoryName) //where TConfiguration : IGameConfiguration
        {
            string[] serializedEntities = RetrieveEntities(repositoryName);
            List<TConfiguration> entities = new List<TConfiguration>();
            foreach (string serializedEntity in serializedEntities)
            {
                TConfiguration? deserializedEntity = JsonSerializer.Deserialize<TConfiguration>(serializedEntity, new JsonSerializerOptions() { IncludeFields = true });
                //if (deserializedEntity == null || !deserializedEntity.IsValid())
                //{
                //    throw new Exception($"Invalid {repositoryName} json.");
                //}
                entities.Add(deserializedEntity);
            }
            return entities.ToArray();
        }

        /// <summary>
        /// Returns an array of strings that represents the string list repository entities; or null, if the file doesn't exist.
        /// </summary>
        /// <param name="persistentStorage"></param>
        /// <param name="repositoryName"></param>
        /// <returns></returns>
        private string[]? LoadEntity(string repositoryName)
        {
            string? serializedEntity = RetrieveEntity(repositoryName);
            if (serializedEntity == null)
            {
                return null;
            }

            string[]? values = JsonSerializer.Deserialize<string[]>(serializedEntity);
            return values;
        }

        public GameConfiguration LoadConfiguration()
        {
            return new GameConfiguration()
            {
                AmuletReadableFlavors = LoadEntities<ReadableFlavorGameConfiguration>("AmuletReadableFlavors"),
                Animations = LoadEntities<AnimationGameConfiguration>("Animations"),
                Attacks = LoadEntities<AttackGameConfiguration>("Attacks"),
                ClassSpells = LoadEntities<ClassSpellGameConfiguration>("ClassSpells"),
                DungeonGuardians = LoadEntities<DungeonGuardianGameConfiguration>("DungeonGuardians"),
                Dungeons = LoadEntities<DungeonGameConfiguration>("Dungeons"),
                GameCommands = LoadEntities<GameCommandGameConfiguration>("GameCommands"),
                Gods = LoadEntities<GodGameConfiguration>("Gods"),
                HelpGroups = LoadEntities<HelpGroupGameConfiguration>("HelpGroups"),
                MonsterRaces = LoadEntities<MonsterRaceGameConfiguration>("MonsterRaces"),
                MushroomReadableFlavors = LoadEntities<ReadableFlavorGameConfiguration>("MushroomReadableFlavors"),
                Plurals = LoadEntities<PluralGameConfiguration>("Plurals"),
                PotionReadableFlavors = LoadEntities<ReadableFlavorGameConfiguration>("PotionReadableFlavors"),
                ProjectileGraphics = LoadEntities<ProjectileGraphicGameConfiguration>("ProjectileGraphics"),
                RingReadableFlavors = LoadEntities<ReadableFlavorGameConfiguration>("RingReadableFlavors"),
                RodReadableFlavors = LoadEntities<ReadableFlavorGameConfiguration>("RodReadableFlavors"),
                ScrollReadableFlavors = LoadEntities<ReadableFlavorGameConfiguration>("ScrollReadableFlavors"),
                Shopkeepers = LoadEntities<ShopkeeperGameConfiguration>("Shopkeepers"),
                Spells = LoadEntities<SpellGameConfiguration>("Spells"),
                StaffReadableFlavors = LoadEntities<ReadableFlavorGameConfiguration>("StaffReadableFlavors"),
                StoreCommands = LoadEntities<StoreCommandGameConfiguration>("StoreCommands"),
                StoreFactories = LoadEntities<StoreFactoryGameConfiguration>("StoreFactories"),
                Symbols = LoadEntities<SymbolGameConfiguration>("Symbols"),
                //Tiles = RetrieveEntities<TileConfiguration>(persistentStorage, "Tiles"), // TODO: This is not working with generic
                Towns = LoadEntities<TownGameConfiguration>("Towns"),
                Vaults = LoadEntities<VaultGameConfiguration>("Vaults"),
                WandReadableFlavors = LoadEntities<ReadableFlavorGameConfiguration>("WandReadableFlavors"),
                WizardCommands = LoadEntities<WizardCommandGameConfiguration>("WizardCommands"),

                ElvishTexts = LoadEntity("ElvishTexts"),
                FindQuests = LoadEntity("FindQuests"),
                FunnyComments = LoadEntity("FunnyComments"),
                FunnyDescriptions = LoadEntity("FunnyDescriptions"),
                HorrificDescriptions = LoadEntity("HorrificDescriptions"),
                InsultPlayerAttacks = LoadEntity("InsultPlayerAttacks"),
                MoanPlayerAttacks = LoadEntity("MoanPlayerAttacks"),
                UnreadableFlavorSyllables = LoadEntity("UnreadableFlavorSyllables"),
                ShopkeeperAcceptedComments = LoadEntity("ShopkeeperAcceptedComments"),
                ShopkeeperBargainComments = LoadEntity("ShopkeeperBargainComments"),
                ShopkeeperGoodComments = LoadEntity("ShopkeeperGoodComments"),
                ShopkeeperLessThanGuessComments = LoadEntity("ShopkeeperLessThanGuessComments"),
                ShopkeeperWorthlessComments = LoadEntity("ShopkeeperWorthlessComments"),
                SingingPlayerAttacks = LoadEntity("SingingPlayerAttacks"),
                WorshipPlayerAttacks = LoadEntity("WorshipPlayerAttacks")
            };
        }
    }
}
