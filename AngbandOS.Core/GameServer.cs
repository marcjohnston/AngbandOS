// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface;
using System.Diagnostics;
using System.Text.Json;

namespace AngbandOS.Core;

/// <summary>
/// Represents a wrapper for an in-progress game.  The Game object has an "internal" scope that prevents the Game and ANY associated objects from being exposed publically.
/// This GameServer object encapsulates the Game object and provides a wrapper that exposes limited functionality as public.
/// </summary>
public class GameServer
{
    /// <summary>
    /// Represents the in-progress game.
    /// </summary>
    private Game Game;

    /// <summary>
    /// Returns the current level of the player.  If the player is dead, null is returned.
    /// </summary>
    /// <returns></returns>
    public int? Level
    {
        get
        {
            if (Game == null || Game.IsDead)
            {
                return null;
            }
            else
            {
                return Game.ExperienceLevel.IntValue;
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
            if (Game == null || Game.IsDead)
            {
                return null;
            }
            else
            {
                return Game.Gold.IntValue;
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
            if (Game == null || Game.IsDead)
            {
                return null;
            }
            else
            {
                return Game.PlayerName.StringValue;
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
            if (Game == null)
            {
                return null;
            }
            return Game.ElapsedGameTime;
        }
    }

    /// <summary>
    /// Returns the date and time when the last input was received from the user.  Returns null, until the game is started.
    /// </summary>
    public DateTime? LastInputReceived
    {
        get
        {
            if (Game?.LastInputReceived == null)
            {
                return null;
            }
            return Game.LastInputReceived;
        }
    }

    /// <summary>
    /// Refresh a spectator console.  
    /// </summary>
    /// <param name="spectatorConsole"></param>
    public void RefreshSpectatorConsole(IViewPort spectatorConsole)
    {
        Game.Screen.RefreshSpectatorConsole(spectatorConsole);
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
        return Game.GetPageOfGameMessages(firstIndex, lastIndex, maximumMessagesToRetrieve);
    }

    /// <summary>
    /// Request the in-progress game to be shutdown.
    /// </summary>
    public void InitiateShutDown()
    {
        if (Game != null)
        {
            Game.Shutdown = true;
        }
    }

    //private TDefinition[] RetrieveEntities<TDefinition>(ICorePersistentStorage persistentStorage, string repositoryName) where TDefinition : IConfiguration
    //{
    //    string[] serializedEntities = persistentStorage.RetrieveEntities(repositoryName);
    //    List<TDefinition> entities = new List<TDefinition>();
    //    foreach (string serializedEntity in serializedEntities)
    //    {
    //        TDefinition? deserializedEntity = JsonSerializer.Deserialize<TDefinition>(serializedEntity);
    //        if (deserializedEntity == null || !deserializedEntity.IsValid())
    //        {
    //            throw new Exception($"Invalid {repositoryName} json.");
    //        }
    //        entities.Add(deserializedEntity);
    //    }
    //    return entities.ToArray();
    //}

    ///// <summary>
    ///// Returns an array of strings that represents the string list repository entities; or null, if the file doesn't exist.
    ///// </summary>
    ///// <param name="persistentStorage"></param>
    ///// <param name="repositoryName"></param>
    ///// <returns></returns>
    //private string[] RetrieveEntity(ICorePersistentStorage persistentStorage, string repositoryName)
    //{
    //    string serializedEntity = persistentStorage.RetrieveEntity(repositoryName);
    //    string[] values = JsonSerializer.Deserialize<string[]>(serializedEntity);
    //    return values;
    //}

    //public Configuration LoadConfiguration(ICorePersistentStorage? persistentStorage)
    //{
    //    return new Configuration()
    //    {
    //        AmuletReadableFlavors = RetrieveEntities<ReadableFlavorConfiguration>(persistentStorage, "AmuletReadableFlavors"),
    //        Animations = RetrieveEntities<AnimationConfiguration>(persistentStorage, "Animations"),
    //        Attacks = RetrieveEntities<AttackConfiguration>(persistentStorage, "Attacks"),
    //        ClassSpells = RetrieveEntities<ClassSpellConfiguration>(persistentStorage, "ClassSpells"),
    //        DungeonGuardians = RetrieveEntities<DungeonGuardianConfiguration>(persistentStorage, "DungeonGuardians"),
    //        Dungeons = RetrieveEntities<DungeonConfiguration>(persistentStorage, "Dungeons"),
    //        GameCommands = RetrieveEntities<GameCommandConfiguration>(persistentStorage, "GameCommands"),
    //        Gods = RetrieveEntities<GodConfiguration>(persistentStorage, "Gods"),
    //        HelpGroups = RetrieveEntities<HelpGroupConfiguration>(persistentStorage, "HelpGroups"),
    //        MonsterRaces = RetrieveEntities<MonsterRaceConfiguration>(persistentStorage, "MonsterRaces"),
    //        MushroomReadableFlavors = RetrieveEntities<ReadableFlavorConfiguration>(persistentStorage, "MushroomReadableFlavors"),
    //        Plurals = RetrieveEntities<PluralConfiguration>(persistentStorage, "Plurals"),
    //        PotionReadableFlavors = RetrieveEntities<ReadableFlavorConfiguration>(persistentStorage, "PotionReadableFlavors"),
    //        ProjectileGraphics = RetrieveEntities<ProjectileGraphicConfiguration>(persistentStorage, "ProjectileGraphics"),
    //        RingReadableFlavors = RetrieveEntities<ReadableFlavorConfiguration>(persistentStorage, "RingReadableFlavors"),
    //        RodReadableFlavors = RetrieveEntities<ReadableFlavorConfiguration>(persistentStorage, "RodReadableFlavors"),
    //        ScrollReadableFlavors = RetrieveEntities<ReadableFlavorConfiguration>(persistentStorage, "ScrollReadableFlavors"),
    //        Shopkeepers = RetrieveEntities<ShopkeeperConfiguration>(persistentStorage, "Shopkeepers"),
    //        Spells = RetrieveEntities<SpellConfiguration>(persistentStorage, "Spells"),
    //        StaffReadableFlavors = RetrieveEntities<ReadableFlavorConfiguration>(persistentStorage, "StaffReadableFlavors"),
    //        StoreCommands = RetrieveEntities<StoreCommandConfiguration>(persistentStorage, "StoreCommands"),
    //        StoreFactories = RetrieveEntities<StoreFactoryConfiguration>(persistentStorage, "StoreFactories"),
    //        Symbols = RetrieveEntities<SymbolConfiguration>(persistentStorage, "Symbols"),
    //        //Tiles = RetrieveEntities<TileConfiguration>(persistentStorage, "Tiles"), // TODO: This is not working with generic
    //        Towns = RetrieveEntities<TownConfiguration>(persistentStorage, "Towns"),
    //        Vaults = RetrieveEntities<VaultConfiguration>(persistentStorage, "Vaults"),
    //        WandReadableFlavors = RetrieveEntities<ReadableFlavorConfiguration>(persistentStorage, "WandReadableFlavors"),
    //        WizardCommands = RetrieveEntities<WizardCommandConfiguration>(persistentStorage, "WizardCommands"),

    //        ElvishTexts = RetrieveEntity(persistentStorage, "ElvishTexts"),
    //        FindQuests = RetrieveEntity(persistentStorage, "FindQuests"),
    //        FunnyComments = RetrieveEntity(persistentStorage, "FunnyComments"),
    //        FunnyDescriptions = RetrieveEntity(persistentStorage, "FunnyDescriptions"),
    //        HorrificDescriptions = RetrieveEntity(persistentStorage, "HorrificDescriptions"),
    //        InsultPlayerAttacks = RetrieveEntity(persistentStorage, "InsultPlayerAttacks"),
    //        MoanPlayerAttacks = RetrieveEntity(persistentStorage, "MoanPlayerAttacks"),
    //        UnreadableFlavorSyllables = RetrieveEntity(persistentStorage, "UnreadableFlavorSyllables"),
    //        ShopkeeperAcceptedComments = RetrieveEntity(persistentStorage, "ShopkeeperAcceptedComments"),
    //        ShopkeeperBargainComments = RetrieveEntity(persistentStorage, "ShopkeeperBargainComments"),
    //        ShopkeeperGoodComments = RetrieveEntity(persistentStorage, "ShopkeeperGoodComments"),
    //        ShopkeeperLessThanGuessComments = RetrieveEntity(persistentStorage, "ShopkeeperLessThanGuessComments"),
    //        ShopkeeperWorthlessComments = RetrieveEntity(persistentStorage, "ShopkeeperWorthlessComments"),
    //        SingingPlayerAttacks = RetrieveEntity(persistentStorage, "SingingPlayerAttacks"),
    //        WorshipPlayerAttacks = RetrieveEntity(persistentStorage, "WorshipPlayerAttacks")
    //    };
    //}

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

        try
        {
            Game = new Game(configuration);
            Game.Play(console, persistentStorage);
        }
        catch (Exception ex)
        {
            console.GameExceptionThrown($"{ex.Message}\n{ex.StackTrace}");
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
            Game = Game.LoadGame(persistentStorage);
            Game.Play(console, persistentStorage);
        }
        catch (Exception ex)
        {
            console.GameExceptionThrown($"{ex.Message}\n{ex.StackTrace}");
            return false;
        }
        return true;
    }
}
