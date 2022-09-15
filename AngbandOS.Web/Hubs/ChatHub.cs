using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents the signal-r hub to process the following incoming and outgoing signal-r chat messages:
    /// - Refresh
    /// - SendMessage
    /// </summary>
    [Authorize]
    public class ChatHub : Hub<IChatHub>
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly IWebPersistentStorage WebPersistentStorage;
        private readonly IHubContext<ServiceHub, IServiceHub> ServiceHub;

        public ChatHub(
            UserManager<ApplicationUser> userManager,
            IHubContext<ServiceHub, IServiceHub> serviceHub,
            IWebPersistentStorage webPersistentStorage
        )
        {
            WebPersistentStorage = webPersistentStorage;
            UserManager = userManager;
            ServiceHub = serviceHub;
        }

        public async Task SendMessage(string? toUsername, string message)
        {
            if (message.Length == 0)
                return;
            
            // We need to ensure the user is authenticated.
            string? emailAddress = Context.User?.FindFirst(ClaimTypes.Email)?.Value;
            ApplicationUser? fromUser = await UserManager.FindByEmailAsync(emailAddress);
            if (fromUser == null)
            {
                await Clients.Client(Context.ConnectionId).MessageFailed();
                return;
            }

            string? toId = null; // Sent to the general public.

            // Check to see if the message was sent privately.
            if (toUsername != null)
            {
                ApplicationUser? toUser = await UserManager.FindByNameAsync(toUsername);
                if (toUser == null)
                {
                    await Clients.Client(Context.ConnectionId).MessageFailed();
                    return;
                }

                // Set the Id of the user it was sent to.
                toId = toUser.Id;
            }

            DateTime now = DateTime.Now;
            int? id = await WebPersistentStorage.WriteMessageAsync(fromUser.Id, toId, message, now, MessageTypeEnum.UserMessage);
            if (id == null)
            {
                await Clients.Client(Context.ConnectionId).MessageFailed();
                return;
            }

            // Now send an update to all of the client.
            ChatMessage chatMessage = new ChatMessage
            {
                fromUsername = fromUser.UserName,
                message = message,
                sentDateTime = now
            };

            // Send the update to all of the chat hub clients.
            await Clients.All.ChatUpdated(chatMessage);

            // And send the update to all of the service hub clients.
            await ServiceHub.Clients.All.ChatUpdated(chatMessage);
        }

        private async Task<string> GetUsernameAsync(string userId)
        {
            ApplicationUser? appUser = await UserManager.FindByIdAsync(userId);
            if (appUser != null)
                return appUser.UserName;
            else
                return "unknown";
        }

        public async Task RefreshChat(int? endingId)
        {
            // Retrieve the messages from the database.
            MessageDetails[] messages = await WebPersistentStorage.GetMessagesAsync(null, endingId);

            // Convert the messages into chat format that they can be sent to the client.
            List<ChatMessage> chatMessages = new List<ChatMessage>();
            foreach (MessageDetails message in messages)
            {
                chatMessages.Add(new ChatMessage
                {
                    fromUsername = await GetUsernameAsync(message.FromId),
                    message = message.Message,
                    sentDateTime = message.SentDateTime
                });
            }

            // Get the hub for the currently connected client.
            IChatHub chatHub = Clients.Client(Context.ConnectionId);

            // Send the response.
            await chatHub.ChatRefreshed(chatMessages.ToArray());
        }


        public override Task OnConnectedAsync()
        {
            // We are not doing anything at this time with the connections.  We should render a list of who is playing though.
            HttpTransportType? transportType = Context.Features.Get<IHttpTransportFeature>()?.TransportType;
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            //ChatService.ChatDisconnected(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
