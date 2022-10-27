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
        Task<bool> DeleteAsync(string id, string username);

        /// <summary>
        /// Retrieve details about all saved games for a particular user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<SavedGameDetails[]> ListAsync(string username);

        /// <summary>
        /// Write a chat message to the database.
        /// </summary>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <param name="message"></param>
        /// <param name="sentDateTime"></param>
        /// <param name="type"></param>
        /// <returns>The unique ID for the message or null, if the message fails to save.</returns>
        Task<MessageDetails?> WriteMessageAsync(string fromId, string? toId, string message, MessageTypeEnum type, string? gameId);

        /// <summary>
        /// Retrieve chat messages from the database.
        /// </summary>
        /// <param name="userId">The ID of the user for which to retrieve chat messages for; null, for public viewing.</param>
        /// <param name="mostRecentMessageId">The ID of the most recent message to retrieve; null, for the most recent messages.  When specified, the system will return older messages.</param>
        /// <returns></returns>-n
        Task<MessageDetails[]> GetMessagesAsync(string? userId, int? mostRecentMessageId, MessageTypeEnum[]? types);
    }
}
