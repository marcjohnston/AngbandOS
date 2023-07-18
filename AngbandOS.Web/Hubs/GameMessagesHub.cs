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
        /// Process an incoming web client request to retrieve a batch of messages.
        /// </summary>
        /// <returns></returns>
        public void GetGameMessages(string gameConnectionId, int? firstIndex, int lastIndex = 0, int? maximumMessagesToRetrieve = null)
        {
            // Forward the request to the game service.
            PageOfGameMessages? pageOfGameMessages = GameService.GetGameMessages(gameConnectionId, firstIndex, lastIndex, maximumMessagesToRetrieve);
            IGameMessagesHub hub = Clients.Client(Context.ConnectionId);
            hub.GameMessagesReceived(pageOfGameMessages);
        }

        public override Task OnConnectedAsync()
        {
            GameService.MessagesHubConnected(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            GameService.MessagesHubDisconnected(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
