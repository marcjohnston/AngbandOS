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
        private readonly IConfiguration Configuration;
        private readonly GameService GameService;

        public ChatHub(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IHubContext<ServiceHub, IServiceHub> serviceHub,
            IWebPersistentStorage webPersistentStorage,
            GameService gameService
        )
        {
            GameService = gameService;
            WebPersistentStorage = webPersistentStorage;
            UserManager = userManager;
            ServiceHub = serviceHub;
            Configuration = configuration;
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

            MessageDetails? messageWritten = await WebPersistentStorage.WriteMessageAsync(fromUser.Id, toId, message, MessageTypeEnum.UserMessage, null);
            if (messageWritten == null)
            {
                await Clients.Client(Context.ConnectionId).MessageFailed();
                return;
            }

            // Now send an update to all of the client.
            ChatMessage chatMessage = new ChatMessage
            {
                Id = messageWritten.Id,
                FromUsername = fromUser.UserName,
                Message = message,
                SentDateTime = messageWritten.SentDateTime
            };

            // Send the update to all of the chat hub clients.
            await Clients.All.ChatUpdated(chatMessage);

            // And send the update to all of the service hub clients.
            await ServiceHub.Clients.All.ChatUpdated(chatMessage);
        }

        public async Task RefreshChat(int? endingId)
        {
            ChatMessage[] chatMessages = await GameService.GetChatMessages(Context.User, endingId);

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
