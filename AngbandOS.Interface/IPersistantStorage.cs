namespace AngbandOS.Interface;

/// <summary>
/// Represents an interface that provides read and write functionailty for saved games.
/// </summary>
public interface IPersistentStorage
{
    /// <summary>
    /// Reads and returns a saved game from the persistent storage.
    /// </summary>
    /// <returns></returns>
    byte[] ReadGame();

    /// <summary>
    /// Writes a saved game to the persistent storage.
    /// </summary>
    /// <param name="gameDetails">Additional details about the game.</param>
    /// <param name="value">The save game to write.</param>
    /// <returns></returns>
    bool WriteGame(GameDetails gameDetails, byte[] value);
}
