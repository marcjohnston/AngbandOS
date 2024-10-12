using AngbandOS.Core.Interface;
using AngbandOS.PersistentStorage.Sql.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace AngbandOS.PersistentStorage
{
    /// <summary>
    /// Represents a Sql driver for AngbandOS to read and write saved games to a Sql database.  
    /// Also supports the ability for a front-end to retrieve SavedGameDetails for a user.
    /// </summary>
    public class SqlGameConfigurationPersistentStorage : IGameConfigurationPersistentStorage
    {
        /// <summary>
        /// Returns the connection string to the database.
        /// </summary>
        protected string ConnectionString { get; }

        /// <summary>
        /// Returns the username to use when reading and writing a saved game to the database.
        /// </summary>
        protected string Username { get; }

        public SqlGameConfigurationPersistentStorage(string connectionString, string username)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException("connectionString");
            }
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }
            ConnectionString = connectionString;
            Username = username;
        }

        private string[] RetrieveEntities(string repositoryName)
        {
            using AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString);
            return context.RepositoryEntities
                .Where(_repositoryEntity => _repositoryEntity.RepositoryName == repositoryName)
                .Select(_repositoryEntity => _repositoryEntity.JsonData)
                .ToArray();
        }

        /// <inheritdoc />
        /// <param name="repositoryName"></param>
        /// <param name="jsonEntities"></param>
        private void PersistEntities(string repositoryName, KeyValuePair<string, string>[] jsonEntities)
        {
            using AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString);

            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Database.ExecuteSqlRaw("DELETE FROM [RepositoryEntities] WHERE [RepositoryName]=@RepositoryName", new SqlParameter("@RepositoryName", repositoryName));
                foreach (KeyValuePair<string, string> jsonEntity in jsonEntities)
                {
                    // Check to see if there is any json data to save.
                    if (jsonEntity.Value.Length > 0)
                    {
                        string key = jsonEntity.Key;
                        context.RepositoryEntities.Add(new RepositoryEntity()
                        {
                            RepositoryName = repositoryName,
                            Key = key,
                            JsonData = jsonEntity.Value
                        });
                    }
                }
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        /// <inheritdoc />
        /// <param name="repositoryName"></param>
        /// <param name="json"></param>
        /// <remarks>Non-keyed entities share the same primary key PK as keyed entities but use the empty string as the key value.</remarks>
        public void PersistEntity(string repositoryName, string json)
        {
            PersistEntities(repositoryName, new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("", json) });
        }

        public string RetrieveEntity(string repositoryName)
        {
            using AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString);
            string? value = context.RepositoryEntities
                .Single(_repositoryEntity => _repositoryEntity.RepositoryName == repositoryName && _repositoryEntity.Key == "")
                .JsonData;
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameConfiguration"></param>
        /// <param name="configurationName"></param>
        /// <param name="overwrite"></param>
        /// <returns>False, if the configuration exists and the <param "overwrite"/> parameter is false; true, if the operation completes successfully.</returns>
        public bool PersistGameConfiguration(Core.Interface.GameConfiguration gameConfiguration, string configurationName, bool overwrite)
        {
            using AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString);

            // Retrieve an existing configuration.
            UserGameConfiguration? userGameConfiguration = context.UserGameConfigurations.SingleOrDefault(_userGameConfiguration => _userGameConfiguration.Name == configurationName && _userGameConfiguration.Username == Username);

            // Check to see if it already exists.
            if (userGameConfiguration != null)
            {
                // Check to see if we are allowed to overwrite it.
                if (!overwrite)
                {
                    return false;
                }
            }
            else
            {
                // Create it and add it to the table.
                userGameConfiguration = new UserGameConfiguration()
                {
                    Username = Username,
                    Name = configurationName,
                };
                context.UserGameConfigurations.Add(userGameConfiguration);
            }

            // Update the configuration entity.
            userGameConfiguration.JsonData = JsonSerializer.Serialize(gameConfiguration);

            context.SaveChanges();

            return true;
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

        public Core.Interface.GameConfiguration LoadConfiguration()
        {
            return new Core.Interface.GameConfiguration()
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
