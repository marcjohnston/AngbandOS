using AngbandOS.Core.Interface;

namespace AngbandOS.Web.Interface
{
    /// <summary>
    /// Represents an interface that persistent storage drivers need to implement for the web interface.
    /// </summary>
    public interface IWebPersistentStorage
    {
        #region Preferences Functionality
        Task<UserSettingsDetails?> GetPreferences(string userId);

        Task<UserSettingsDetails> WritePreferencesAsync(string userId, UserSettingsDetails userSettingsDetails);
        #endregion

        #region Save and Load Game Functionality
        byte[]? ReadGame(string username, string gameGuid);
        bool WriteGame(string username, string gameGuid, GameDetails gameDetails, byte[] value);
        #endregion

        #region Messaging and Chat Functionality
        /// <summary>
        /// Deletes a game from the database.
        /// </summary>
        /// <param name="id">The ID (guid) of the game to be deleted.</param>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(string id, string username);

        /// <summary>
        /// Returns details about the saved games associated to a user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<SavedGameDetails[]> ListAsync(string username);

        /// <summary>
        /// Writes a message record to the database.
        /// </summary>
        /// <param name="fromId">The ID (guid) of the user from which the message is from.</param>
        /// <param name="toId">The ID (guid) of the user the message is intended for.  Null, if the message is not intended for a recipient.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="type">The type of message being sent/written.</param>
        /// <param name="gameId">A ID (guid) of the game the message is related to.  Null, if the message is not related to a game.</param>
        /// <returns>The unique ID for the message or null, if the message fails to save.</returns>
        Task<MessageDetails?> WriteMessageAsync(string fromId, string? toId, string message, MessageTypeEnum type, string? gameId);

        /// <summary>
        /// Returns messages from the database for any specific user.  All users get to read all messages that are not sent directly to another user.  Logged in users
        /// will get to also read all messages but they will also get messages sent directly to them.
        /// </summary>
        /// <param name="userId">The id of the user requesting the messages or null for an anonymous user.</param>
        /// <param name="mostRecentMessageId">The most recent ID of the message to return.  Only messages prior to this ID will be returned.  Used for scrolling.</param>
        /// <param name="types">List of message types that the user should receive or null for ALL.</param>
        /// <returns></returns>
        Task<MessageDetails[]> GetMessagesAsync(string? userId, int? mostRecentMessageId, MessageTypeEnum[]? types, bool includeDeleted);

        /// <summary>
        /// Deletes a message from the database.
        /// </summary>
        /// <param name="messageId">The id of the message.</param>
        /// <returns></returns>
        Task<bool> DeleteMessagesAsync(int messageId);
        #endregion

        #region Game Replay Functionality
        /// <summary>
        /// Read game replay details from the database.
        /// </summary>
        /// <param name="gameGuid"></param>
        /// <returns></returns>
        (GameReplayDetails, int) GetReplay(string gameGuid);

        /// <summary>
        /// Save the game seed and return a unique identifier for game replay steps.
        /// </summary>
        /// <param name="gameGuid"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        int GenerateGameReplayGameId(string gameGuid, int seed);

        /// <summary>
        /// Save a replay step in the database.
        /// </summary>
        /// <param name="gameReplayId">Provide the unique game replay identifier that was returned from the <see cref="GenerateGameReplayGameId(string, int)"/> method.</param>
        /// <param name="dateTime"></param>
        /// <param name="keystroke"></param>
        /// <param name="seed"></param>
        /// <param name="stackTrace"></param>
        void WriteStep(int gameReplayId, DateTime dateTime, char keystroke, int seed, string? stackTrace);

        /// <summary>
        /// Retrieve the game replay unique identifier for an existing game.
        /// </summary>
        /// <param name="gameGuid"></param>
        /// <returns></returns>
        int GetGameReplayId(string gameGuid);
        #endregion
    }
}
