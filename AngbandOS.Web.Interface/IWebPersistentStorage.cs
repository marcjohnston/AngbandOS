namespace AngbandOS.Web.Interface
{
    /// <summary>
    /// Represents an interface that a persistent storage driver needs to implement for the web interface.
    /// </summary>
    public interface IWebPersistentStorage
    {
        /// <summary>
        /// Delete a saved game.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        bool Delete(string id, string username);

        /// <summary>
        /// Retrieve details about all saved games for a particular user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        SavedGameDetails[] List(string username);

        bool WriteMessage(string fromId, string toId, string message, DateTime sentDateTime);
        Message[] GetMessages(string userId, int? mostRecentMessageId);
    }
}
