using AngbandOS.Core.Interface;
using Microsoft.AspNetCore.SignalR;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents the signal-r hub singleton service to process incoming and outgoing signal-r messages for the messages window.
    /// This hub is identical to the game-hub, except it allows anonymous requests.
    /// </summary>
    public class GameMessagesHub : Hub<IGameMessagesHub>
    {
        private readonly GameService GameService;

        public GameMessagesHub(
            GameService gameService
        )
        {
            GameService = gameService;
        }

        /// <summary>
        /// Process an incoming web client request to retrieve a batch of messages.  This will occur when the user scrolls.
        /// </summary>
        /// <returns></returns>
        public void GetGameMessages(string gameConnectionId, int? firstIndex, int lastIndex = 0, int? maximumMessagesToRetrieve = null)
        {
            // Forward the request to the game service.
            PageOfGameMessages? pageOfGameMessages = GameService.GetGameMessages(gameConnectionId, firstIndex, lastIndex, maximumMessagesToRetrieve);
            IGameMessagesHub hub = Clients.Client(Context.ConnectionId);
            hub.GameMessagesReceived(pageOfGameMessages);
        }

        /// <summary>
        /// Processes an incoming web client request to monitor the game messages for a specific game.  This request is forwarded to the singleton game service so 
        /// that it can be sent to the signal-r console that is hosting the game.
        /// </summary>
        /// <param name="gameConnectionId">The game connection identifier.</param>
        /// <param name="maximumMessagesToRetrieve">The maximum messages to retrieve.</param>
        public void MonitorGameMessages(string gameConnectionId, int? maximumMessagesToRetrieve = null)
        {
            // Forward the request to the game service.
            IGameMessagesHub monitorHub = Clients.Client(Context.ConnectionId);
            GameService.MonitorGameMessages(monitorHub, gameConnectionId, maximumMessagesToRetrieve);
        }

        public override Task OnConnectedAsync()
        {
            GameService.GameMessagesHubConnected(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            GameService.GameMessagesHubDisconnected(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
