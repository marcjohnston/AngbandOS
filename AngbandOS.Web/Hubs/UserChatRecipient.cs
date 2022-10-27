using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;

namespace AngbandOS.Web.Hubs
{
    public class UserChatRecipient : ChatRecipient
    {
        private readonly string UserId;
        private readonly IChatHub ChatHub;

        public UserChatRecipient(IChatHub chatHub, string userId, string username) : base(username)
        {
            UserId = userId;
            ChatHub = chatHub;
        }

        public async override Task SendUpdateAsync(MessageTypeEnum messageType, string toId, ChatMessage chatMessage)
        {
            // All character died messages and non-private messages will be sent to anonymous users.
            if (messageType == MessageTypeEnum.CharacterDied || (messageType == MessageTypeEnum.UserMessage && toId == null) || toId == UserId)
                await ChatHub.ChatUpdated(chatMessage);
        }

        public override async Task<MessageDetails[]> GetMessagesAsync(IWebPersistentStorage webPersistentStorage, int? endingId)
        {
            MessageTypeEnum[] messageTypes = new MessageTypeEnum[] { MessageTypeEnum.UserMessage, MessageTypeEnum.CharacterDied };
            return await webPersistentStorage.GetMessagesAsync(UserId, endingId, messageTypes);
        }
    }
}
