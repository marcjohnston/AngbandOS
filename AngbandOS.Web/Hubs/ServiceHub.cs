using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents the signal-r hub singleton service for the home screen that monitors active games.
    /// </summary>
    public class ServiceHub : Hub<IServiceHub>
    {
        private readonly GameService GameService;
//        private readonly IHubContext<ServiceHub, IServiceHub> ServiceHub;
        private readonly IWebPersistentStorage WebPersistentStorage;
        private readonly UserManager<ApplicationUser> UserManager; // We need to be able to retrieve usernames and accounts

        public ServiceHub(
            IHubContext<ServiceHub, IServiceHub> serviceHub,
            UserManager<ApplicationUser> userManager,
            IWebPersistentStorage webPersistentStorage,
            GameService gameService
        )
        {
//            ServiceHub = serviceHub;
            GameService = gameService;
            WebPersistentStorage = webPersistentStorage;
            UserManager = userManager;
        }

        public void RefreshActiveGames()
        {
            // Immediately send a seeding list of active games to the client.
            ActiveGameDetails[] activeGames = GameService.GetActiveGames();
            IServiceHub serviceHub = Clients.Client(Context.ConnectionId);
            serviceHub.ActiveGamesUpdated(activeGames);
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
            IServiceHub serviceHub = Clients.Client(Context.ConnectionId);

            // Send the response.
            await serviceHub.ChatRefreshed(chatMessages.ToArray());
        }

        public override Task OnConnectedAsync()
        {
            // We are not doing anything at this time with the connections.  We should render a list of who is playing though.
            HttpTransportType? transportType = Context.Features.Get<IHttpTransportFeature>()?.TransportType;
            return base.OnConnectedAsync();
        }
    }
}
