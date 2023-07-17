// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

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
            if (SaveGame?.Player == null)
                return null;
            else
                return SaveGame.Player.Level;
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
            if (SaveGame?.Player == null)
                return null;
            else
                return SaveGame.Player.Gold;
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
            if (SaveGame?.Player == null)
                return null;
            else
                return SaveGame.Player.Name;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public TimeSpan? ElapsedGameTime
    {
        get
        {
            if (SaveGame?.Player?.GameTime == null)
                return null;
            return SaveGame.Player.GameTime.ElapsedGameTime;
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
    public void RefreshSpectatorConsole(IConsole spectatorConsole)
    {
        SaveGame.Screen.RefreshSpectatorConsole(spectatorConsole);
    }

    /// <summary>
    /// Retrieves a block of messages.  Messages are assigned a unique sequential index when they are generated.
    /// </summary>
    /// <param name="firstMessageIndex">The zero-based index of the first message to retrieve.  Defaults to index 0.</param>
    /// <param name="lastMessageIndex">The index of the last message to retrieve.  Defaults to null, to retrieve all remaining messages.</param>
    public void GetMessages(int firstIndex = 0, int? lastIndex = null)
    {

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

    /// <summary>
    /// Plays a game.  If the game cannot be played false is immediately returned; otherwise, the game is played out and true is returned when the game is over.
    /// </summary>
    /// <param name="console"></param>
    /// <param name="persistentStorage">The object responsible for saving the game.  If this object is not provided, the game will not be saved.</param>
    /// <param name="updateMonitor"></param>
    /// <param name="configuration">Represents configuration data to use when generating a new game.</param>
    /// <returns></returns>
    public bool PlayNewGame(IConsole console, ICorePersistentStorage? persistentStorage, IUpdateMonitor? updateMonitor = null, Configuration? configuration = null)
    {
        if (console == null)
        {
            throw new ArgumentNullException("console", "A console object must be provided and cannot be null.");
        }

        try
        {
            SaveGame = SaveGame.CreateNew(configuration);
            SaveGame.Play(console, persistentStorage, updateMonitor);
        }
        catch (Exception ex)
        {
            updateMonitor?.GameExceptionThrown(ex.Message);
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
    public bool PlayExistingGame(IConsole console, ICorePersistentStorage persistentStorage, IUpdateMonitor? updateMonitor = null)
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
            SaveGame.Play(console, persistentStorage, updateMonitor);
        }
        catch (Exception ex)
        {
            updateMonitor?.GameExceptionThrown(ex.Message);
            return false;
        }
        return true;
    }
}
