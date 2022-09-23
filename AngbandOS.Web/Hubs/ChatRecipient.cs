using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;

namespace AngbandOS.Web.Hubs
{
    public abstract class ChatRecipient
    {
        public abstract Task SendUpdateAsync(MessageTypeEnum messageType, string toId, ChatMessage chatMessage);
        public abstract Task<MessageDetails[]> GetMessagesAsync(IWebPersistentStorage webPersistentStorage, int? endingId);
    }
}
