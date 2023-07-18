using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents an anonymous signal-r hub singleton service for the home screen that monitors active games and provides public read-only chats.
    /// </summary>
    public class ServiceHub : Hub<IServiceHub>
    {
        private readonly GameService GameService;
        private readonly IWebPersistentStorage WebPersistentStorage;
        private readonly UserManager<ApplicationUser> UserManager; // We need to be able to retrieve usernames and accounts
        private readonly IConfiguration Configuration;

        public ServiceHub(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IWebPersistentStorage webPersistentStorage,
            GameService gameService
        )
        {
            GameService = gameService;
            WebPersistentStorage = webPersistentStorage;
            UserManager = userManager;
            Configuration = configuration;
        }

        public void RefreshActiveGames()
        {
            // Immediately send a seeding list of active games to the client.
            ActiveGameDetails[] activeGames = GameService.GetActiveGames();
            IServiceHub serviceHub = Clients.Client(Context.ConnectionId);
            serviceHub.ActiveGamesUpdated(activeGames);
        }

        public void RefreshActiveUsers()
        {
            //// Immediately send a seeding list of active games to the client.
            ActiveUserDetails[] activeUsers = GameService.GetChatUsers();
            IServiceHub serviceHub = Clients.Client(Context.ConnectionId);
            serviceHub.ActiveUsersRefreshed(activeUsers);
        }

        public async Task RefreshChat(int? endingId)
        {
            ChatMessage[] chatMessages = await GameService.GetChatMessagesAsync(Context.ConnectionId, endingId);

            // Get the hub for the currently connected client.
            IServiceHub serviceHub = Clients.Client(Context.ConnectionId);

            // Send the response.
            await serviceHub.ChatRefreshed(chatMessages);
        }

        /// <summary>
        /// Triggered by signal-r when a user connects to the service hub on the home screen.  This message is fowarded to the GameService.
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            //HttpTransportType? transportType = Context.Features.Get<IHttpTransportFeature>()?.TransportType; // This was to determine what type of transport was being used so that the dashboard can render it.  It isn't ready yet though.
            IServiceHub serviceHub = Clients.Client(Context.ConnectionId);

            // Add this connection to the service hub connections.
            GameService.ServiceHubConnected(Context.ConnectionId);

            // Connect the client to the chat.
            GameService.ChatConnected(Context.ConnectionId, new AnonymousChatRecipient(serviceHub));

            return base.OnConnectedAsync();
        }

        /// <summary>
        /// Triggered by signal-r when a user disconnects from the service hub on the home screen.  This message is forwarded to the GameService.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            GameService.ServiceHubDisconnected(Context.ConnectionId);
            GameService.ChatDisconnected(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
