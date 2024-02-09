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
    /// Persist multiple non-null, non-blank keyed entities to the persistent storage--overwriting all other entities in the same repository identified by the 
    /// repository name parameter.
    /// </summary>
    /// <param name="repositoryName">Specify the name of the repository.</param>
    /// <param name="jsonEntities">Specify an array of key/value pairs.</param>
    void PersistEntities(string repositoryName, KeyValuePair<string, string>[] jsonEntities);

    /// <summary>
    /// Persist a single non-keyed entity to the persistent storage--overwriting all other entities in the same repository identified by the repository name parameter.
    /// </summary>
    /// <param name="repositoryName"></param>
    /// <param name="json"></param>
    void PersistEntity(string repositoryName, string json);

    /// <summary>
    /// Retrieve multiple keyed entities from the persistent storage.
    /// </summary>
    /// <param name="repositoryName"></param>
    /// <returns></returns>
    string[] RetrieveEntities(string repositoryName);

    /// <summary>
    /// Retrieve a single non-keyed entity from the persistent storage.
    /// </summary>
    /// <param name="repositoryName"></param>
    /// <returns></returns>
    string RetrieveEntity(string repositoryName);
}
