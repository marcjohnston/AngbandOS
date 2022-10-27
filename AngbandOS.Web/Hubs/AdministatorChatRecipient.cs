using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;

namespace AngbandOS.Web.Hubs
{
    public class AdministatorChatRecipient : ChatRecipient
    {
        private readonly string UserId;
        private readonly IChatHub ChatHub;

        public AdministatorChatRecipient(IChatHub chatHub, string userId, string username) : base(username)
        {
            ChatHub = chatHub;
            UserId = userId;
        }

        public async override Task SendUpdateAsync(MessageTypeEnum messageType, string toId, ChatMessage chatMessage)
        {
            // All character died messages and non-private messages will be sent to anonymous users.
            await ChatHub.ChatUpdated(chatMessage);
        }

        public override async Task<MessageDetails[]> GetMessagesAsync(IWebPersistentStorage webPersistentStorage, int? endingId)
        {
            return await webPersistentStorage.GetMessagesAsync(UserId, endingId, null);
        }
    }
}
