namespace AngbandOS.Interface
{
    public interface IPersistentStorage
    {
        /// <summary>
        /// Reads and returns a saved game from the persistent storage.
        /// </summary>
        /// <param name="username">The name of the user for which the game belongs to.</param>
        /// <param name="guid">The unique identifier for the game.</param>
        /// <returns></returns>
        byte[] ReadGame(string username, string guid);

        /// <summary>
        /// Writes a saved game to the persistent storage.
        /// </summary>
        /// <param name="username">The name of the user to associate the game with.</param>
        /// <param name="guid">The unique idenifier for the game.</param>
        /// 
        /// <param name="value">The save game to write.</param>
        /// <returns></returns>
        bool WriteGame(string username, string guid, GameDetails gameDetails, byte[] value);

        SavedGameDetails[] ListSavedGames(string username);
    }
}
