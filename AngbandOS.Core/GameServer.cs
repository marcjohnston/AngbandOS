// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents an encapsulating wrapper for an in-progrss game.  This wrapper exposes public functionality.
/// SaveGame objects are internal.
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
    /// Request the in-progress game to be shutdown.
    /// </summary>
    public void InitiateShutDown()
    {
        if (SaveGame != null)
            SaveGame.Shutdown = true;
    }

    /// <summary>
    /// Plays a game and returns false, if the game cannot be played, true when the game is over.
    /// </summary>
    /// <param name="console"></param>
    /// <param name="persistentStorage"></param>
    /// <param name="updateNotifier"></param>
    /// <param name="configuration">Represents configuration data to use when generating a new game.</param>
    /// <returns></returns>
    public bool Play(IConsole console, ICorePersistentStorage persistentStorage, IUpdateNotifier updateNotifier, Configuration? configuration = null)
    {
        try
        {
            // Retrieve the game from persistent storage
            SaveGame = SaveGame.Initialize(persistentStorage, configuration);
            SaveGame.Play(console, persistentStorage, updateNotifier);
        }
        catch (Exception ex)
        {
            updateNotifier?.GameExceptionThrown(ex.Message);
            return false;
        }
        return true;
    }
}
