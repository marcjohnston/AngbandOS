using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents a chat recipient for an anonymous user.  History messages are filtered for anonymous users.  Anonymous users are limited to character died and all non-private messages.
    /// </summary>
    public class AnonymousChatRecipient : ChatRecipient
    {
        private readonly IServiceHub ServiceHub;

        public AnonymousChatRecipient(IServiceHub serviceHub) : base("Anonymous")
        {
            ServiceHub = serviceHub;
        }

        public async override Task SendUpdateAsync(MessageTypeEnum messageType, string toId, ChatMessage chatMessage)
        {
            // All character died messages and non-private messages will be sent to anonymous users.
            if (messageType == MessageTypeEnum.CharacterDied || (messageType == MessageTypeEnum.UserMessage && toId == null))
            {
                await ServiceHub.ChatUpdated(chatMessage);
            }
        }

        public override async Task<MessageDetails[]> GetMessagesAsync(IWebPersistentStorage webPersistentStorage, int? endingId)
        {
            MessageTypeEnum[] messageTypes = new MessageTypeEnum[] { MessageTypeEnum.UserMessage, MessageTypeEnum.CharacterDied };

            // Deleted messages are available to anonymous users.
            return await webPersistentStorage.GetMessagesAsync(null, endingId, messageTypes, false);
        }
    }
}
