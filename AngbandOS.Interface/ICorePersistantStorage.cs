namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents an interface that provides core read and write functionality for saved games.
/// </summary>
public interface ICorePersistentStorage
{
    /// <summary>
    /// Reads and returns a saved game from the persistent storage.  Returns null, if the game does not exist.
    /// </summary>
    /// <returns></returns>
    byte[]? ReadGame();

    /// <summary>
    /// Writes a saved game to the persistent storage.
    /// </summary>
    /// <param name="gameDetails">Additional details about the game.</param>
    /// <param name="value">The save game to write.</param>
    /// <returns></returns>
    bool WriteGame(GameDetails gameDetails, byte[] value);

    /// <summary>
    /// Returns true, if a persisted game exists.  False, otherwise.
    /// </summary>
    /// <returns></returns>
    bool GameExists();

    /// <summary>
    /// Persist one or more entities to the persistent storage.  For ListRepository entities, provide a single jsonEntity with an empty string key value.
    /// </summary>
    /// <param name="repositoryName">Specify the name of the repository.</param>
    /// <param name="jsonEntities">Specify an array of key/value pairs.</param>
    void PersistEntities(string repositoryName, KeyValuePair<string, string>[] jsonEntities);

    string[] RetrieveEntities(string repositoryName);
}
