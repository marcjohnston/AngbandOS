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

        public override Task OnConnectedAsync()
        {
            // We are not doing anything at this time with the connections.  We should render a list of who is playing though.
            HttpTransportType? transportType = Context.Features.Get<IHttpTransportFeature>()?.TransportType;
            IServiceHub serviceHub = Clients.Client(Context.ConnectionId);
            GameService.ServiceHubConnected(Context.ConnectionId);
            GameService.ChatConnected(Context.ConnectionId, new AnonymousChatRecipient(serviceHub));
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            GameService.ServiceHubDisconnected(Context.ConnectionId);
            GameService.ChatDisconnected(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
