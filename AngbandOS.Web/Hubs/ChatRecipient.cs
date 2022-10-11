using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;

namespace AngbandOS.Web.Hubs
{
    public abstract class ChatRecipient
    {
        /// <summary>
        /// Returns the name of the user.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Returns the date and time the chat recipient connected.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Sends a message to the user, if the user can receive the message.  Various derived classes will limit the types of messages the user
        /// can receive based on the type of connection and/or account.
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="toId"></param>
        /// <param name="chatMessage"></param>
        /// <returns></returns>
        public abstract Task SendUpdateAsync(MessageTypeEnum messageType, string toId, ChatMessage chatMessage);

        /// <summary>
        /// Retrieves messages from the database upon request.
        /// </summary>
        /// <param name="webPersistentStorage"></param>
        /// <param name="endingId"></param>
        /// <returns></returns>
        public abstract Task<MessageDetails[]> GetMessagesAsync(IWebPersistentStorage webPersistentStorage, int? endingId);

        public ChatRecipient(string username)
        {
            Username = username;
            DateTimeOffset dateTime = DateTime.UtcNow;
        }
    }
}
