// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Flavors;
using System.Text.Json;

namespace AngbandOS.Core;

/// <summary>
/// Represents a wrapper for an in-progress game.  The SaveGame object has an "internal" scope that prevents the SaveGame and ANY associated objects from being exposed publically.
/// This GameServer object encapsulates the SaveGame object and provides a wrapper that exposes limited functionality as public.
/// </summary>
public class GameServer
{
    /// <summary>
    /// Represents the in-progress game.
    /// </summary>
    private SaveGame SaveGame;

    /// <summary>
    /// Returns the current level of the player.  If the player is dead, null is returned.
    /// </summary>
    /// <returns></returns>
    public int? Level
    {
        get
        {
            if (SaveGame == null || SaveGame.IsDead)
            {
                return null;
            }
            else
            {
                return SaveGame.ExperienceLevel;
            }
        }
    }

    /// <summary>
    /// Returns the current amount of gold the player has.  If the player is dead, null is returned.
    /// </summary>
    /// <returns></returns>
    public int? Gold
    {
        get
        {
            if (SaveGame == null || SaveGame.IsDead)
            {
                return null;
            }
            else
            {
                return SaveGame.Gold;
            }
        }
    }

    /// <summary>
    /// Returns the character name of the player.  If the player is dead, null is returned.
    /// </summary>
    /// <returns></returns>
    public string? CharacterName
    {
        get
        {
            if (SaveGame == null || SaveGame.IsDead)
            {
                return null;
            }
            else
            {
                return SaveGame.Name;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public TimeSpan? ElapsedGameTime
    {
        get
        {
            if (SaveGame == null || SaveGame.GameTime == null)
            {
                return null;
            }
            return SaveGame.GameTime.ElapsedGameTime;
        }
    }

    /// <summary>
    /// Returns the date and time when the last input was received from the user.  Returns null, until the game is started.
    /// </summary>
    public DateTime? LastInputReceived
    {
        get
        {
            if (SaveGame?.LastInputReceived == null)
            {
                return null;
            }
            return SaveGame.LastInputReceived;
        }
    }

    /// <summary>
    /// Refresh a spectator console.  
    /// </summary>
    /// <param name="spectatorConsole"></param>
    public void RefreshSpectatorConsole(IViewPort spectatorConsole)
    {
        SaveGame.Screen.RefreshSpectatorConsole(spectatorConsole);
    }

    /// <summary>
    /// Retrieves a block of messages.  Messages are assigned a unique sequential 0-based index when they are generated with the earliest message assigned an index of 0.  Messages
    /// are retrieved in reverse order; in other words, the index of the first message to retrieve must be higher than the index of the last index to retrieve.  For example, requesting
    /// the messages with the first index = 100 and the last index = 50 will retrieve messages from index 100 down to index 50.  This is done to assist in retrieval efforts for 
    /// maintaining recent messages and scrolling through older messages.
    /// 
    /// Usage scenarios:
    /// FirstIndex  LastIndex   MaximumCount    Description
    /// null        0           null            Will retrieve all messages from the log.  This is useful to obtain the entire log.
    /// null        0           50              Up to 50 of the most recent messages from the log will be returned.  This is useful for rendering the first screen of a scrollable log.
    /// 50          0           50              Will return a block of up to 50 messages starting from index 50 going down to 0.  This is useful when the user is scrolling.
    /// null        51          null            Will return all of the messages that have been generated up to and including index 51.  This is useful when an updating an existing window of messages.
    /// 
    /// 50          50          null            Will return message 50 and only message 50, if it exists.
    /// 50          50          0               Will not return any messages.
    /// 50          50          2               Will return message 50 and only message 50, if it exists.
    ///
    /// Special considerations:
    /// 50          100         null            Will throw an exception because the last index must be smaller than the first index and there is no maximum count to override the last index.
    /// 50          0           10              The LastIndex value will be ignored and will return a block of up to 10 messages starting from index 50 going down to 40.
    /// 50          100         10              Will throw an exception because the last index must be smaller than the first index and there is no maximum count to override the last index.
    /// <0          <0          <0              Will throw an exception if any parameter is less than zero.
    /// </summary>
    /// <param name="firstMessageIndex">The zero-based index of the first message to retrieve.  Defaults to null, which indicates to retrieve the most-recent message from the log.</param>
    /// <param name="lastMessageIndex">The zero-based index of the last message to retrieve.  Defaults to 0, which indicates to retrieve the oldest message from the log.</param>
    /// <param name="firstIndex">The maximum number of records to return.  Defaults to null, which does not limit the number of records.</param>
    public PageOfGameMessages? GetPageOfGameMessages(int? firstIndex = null, int lastIndex = 0, int? maximumMessagesToRetrieve = null)
    {
        return SaveGame.GetPageOfGameMessages(firstIndex, lastIndex, maximumMessagesToRetrieve);
    }

    /// <summary>
    /// Request the in-progress game to be shutdown.
    /// </summary>
    public void InitiateShutDown()
    {
        if (SaveGame != null)
        {
            SaveGame.Shutdown = true;
        }
    }

    private TDefinition[] RetrieveEntities<TDefinition>(ICorePersistentStorage persistentStorage, string repositoryName) where TDefinition : IPoco
    {
        string[] serializedEntities = persistentStorage.RetrieveEntities(repositoryName);
        List<TDefinition> entities = new List<TDefinition>();
        foreach (string serializedEntity in serializedEntities)
        {
            TDefinition? deserializedEntity = JsonSerializer.Deserialize<TDefinition>(serializedEntity);
            if (deserializedEntity == null || !deserializedEntity.IsValid())
            {
                throw new Exception($"Invalid {repositoryName} json.");
            }
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
    private string[] RetrieveEntity(ICorePersistentStorage persistentStorage, string repositoryName)
    {
        string serializedEntity = persistentStorage.RetrieveEntity(repositoryName);
        string[] values = JsonSerializer.Deserialize<string[]>(serializedEntity);
        return values;
    }
    /// <summary>
    /// Plays a game.  If the game cannot be played false is immediately returned; otherwise, the game is played out and true is returned when the game is over.
    /// </summary>
    /// <param name="console"></param>
    /// <param name="persistentStorage">The object responsible for saving the game.  If this object is not provided, the game will not be saved.</param>
    /// <param name="updateMonitor"></param>
    /// <param name="configuration">Represents configuration data to use when generating a new game.</param>
    /// <returns></returns>
    public bool PlayNewGame(IConsoleViewPort console, ICorePersistentStorage? persistentStorage, Configuration? configuration = null)
    {
        if (console == null)
        {
            throw new ArgumentNullException("console", "A console object must be provided and cannot be null.");
        }

        if (persistentStorage != null && configuration == null) {
            configuration = new Configuration()
            {
                AmuletReadableFlavors = RetrieveEntities<ReadableFlavorDefinition>(persistentStorage, Pluralize(nameof(AmuletReadableFlavor))),
                ClassSpells = RetrieveEntities<ClassSpellDefinition>(persistentStorage, Pluralize(nameof(ClassSpell))),
                DungeonGuardians = RetrieveEntities<DungeonGuardianDefinition>(persistentStorage, Pluralize(nameof(DungeonGuardian))),
                Dungeons = RetrieveEntities<DungeonDefinition>(persistentStorage, Pluralize(nameof(Dungeon))),
                GameCommands = RetrieveEntities<GameCommandDefinition>(persistentStorage, Pluralize(nameof(GameCommand))),
                HelpGroups = RetrieveEntities<HelpGroupDefinition>(persistentStorage, Pluralize(nameof(HelpGroup))),
                MonsterRaces = RetrieveEntities<MonsterRaceDefinition>(persistentStorage, Pluralize(nameof(MonsterRace))),
                MushroomReadableFlavors = RetrieveEntities<ReadableFlavorDefinition>(persistentStorage, Pluralize(nameof(MushroomReadableFlavor))),
                PotionReadableFlavors = RetrieveEntities<ReadableFlavorDefinition>(persistentStorage, Pluralize(nameof(PotionReadableFlavor))),
                ProjectileGraphics = RetrieveEntities<ProjectileGraphicDefinition>(persistentStorage, Pluralize(nameof(ProjectileGraphic))),
                RingReadableFlavors = RetrieveEntities<ReadableFlavorDefinition>(persistentStorage, Pluralize(nameof(RingReadableFlavor))),
                RodReadableFlavors = RetrieveEntities<ReadableFlavorDefinition>(persistentStorage, Pluralize(nameof(RodReadableFlavor))),
                ScrollReadableFlavors = RetrieveEntities<ReadableFlavorDefinition>(persistentStorage, Pluralize(nameof(ScrollReadableFlavor))),
                Shopkeepers = RetrieveEntities<ShopkeeperDefinition>(persistentStorage, Pluralize(nameof(Shopkeeper))),
                StaffReadableFlavors = RetrieveEntities<ReadableFlavorDefinition>(persistentStorage, Pluralize(nameof(StaffReadableFlavor))),
                StoreCommands = RetrieveEntities<StoreCommandDefinition>(persistentStorage, Pluralize(nameof(StoreCommand))),
                StoreFactories = RetrieveEntities<StoreFactoryDefinition>(persistentStorage, Pluralize(nameof(StoreFactory))),
                Symbols = RetrieveEntities<SymbolDefinition>(persistentStorage, Pluralize(nameof(Symbol))),
                Tiles = RetrieveEntities<TileDefinition>(persistentStorage, Pluralize(nameof(Tile))),
                Towns = RetrieveEntities<TownDefinition>(persistentStorage, Pluralize(nameof(Town))),
                Vaults = RetrieveEntities<VaultDefinition>(persistentStorage, Pluralize(nameof(Vault))),
                WandReadableFlavors = RetrieveEntities<ReadableFlavorDefinition>(persistentStorage, Pluralize(nameof(WandReadableFlavor))),
                WizardCommands = RetrieveEntities<WizardCommandDefinition>(persistentStorage, Pluralize(nameof(WizardCommand))),

                ElvishTexts = RetrieveEntity(persistentStorage, "ElvishTexts"),
                FindQuests = RetrieveEntity(persistentStorage, "FindQuests"),
                FunnyComments = RetrieveEntity(persistentStorage, "FunnyComments"),
                FunnyDescriptions = RetrieveEntity(persistentStorage, "FunnyDescriptions"),
                HorrificDescriptions = RetrieveEntity(persistentStorage, "HorrificDescriptions"),
                InsultPlayerAttacks = RetrieveEntity(persistentStorage, "InsultPlayerAttacks"),
                MoanPlayerAttacks = RetrieveEntity(persistentStorage, "MoanPlayerAttacks"),
                UnreadableFlavorSyllables = RetrieveEntity(persistentStorage, "UnreadableFlavorSyllables"),
                ShopkeeperAcceptedComments = RetrieveEntity(persistentStorage, "ShopkeeperAcceptedComments"),
                ShopkeeperBargainComments = RetrieveEntity(persistentStorage, "ShopkeeperBargainComments"),
                ShopkeeperGoodComments = RetrieveEntity(persistentStorage, "ShopkeeperGoodComments"),
                ShopkeeperLessThanGuessComments = RetrieveEntity(persistentStorage, "ShopkeeperLessThanGuessComments"),
                ShopkeeperWorthlessComments = RetrieveEntity(persistentStorage, "ShopkeeperWorthlessComments"),
                SingingPlayerAttacks = RetrieveEntity(persistentStorage, "SingingPlayerAttacks"),
                WorshipPlayerAttacks = RetrieveEntity(persistentStorage, "WorshipPlayerAttacks")
            };
        }

        try
        {
            SaveGame = new SaveGame(configuration);
            SaveGame.Play(console, persistentStorage);
        }
        catch (Exception ex)
        {
            console.GameExceptionThrown(ex.Message);
            return false;
        }
        return true;
    }

    /// <summary>
    /// Plays an existing game.  If the game cannot be played false is immediately returned; otherwise, the game is played out and true is returned when the game is over.
    /// </summary>
    /// <param name="console"></param>
    /// <param name="persistentStorage"></param>
    /// <param name="updateMonitor"></param>
    /// <returns></returns>
    public bool PlayExistingGame(IConsoleViewPort console, ICorePersistentStorage persistentStorage)
    {
        if (console == null)
        {
            throw new ArgumentNullException("console", "A console object must be provided and cannot be null.");
        }
        if (persistentStorage == null)
        {
            throw new ArgumentNullException("persistentStorage", "A persistentStorage object must be provided to retrieve the game from persistent storage and cannot be null.");
        }

        try
        {
            // Retrieve the game from persistent storage.
            SaveGame = SaveGame.LoadGame(persistentStorage);
            SaveGame.Play(console, persistentStorage);
        }
        catch (Exception ex)
        {
            console.GameExceptionThrown(ex.Message);
            return false;
        }
        return true;
    }
}
