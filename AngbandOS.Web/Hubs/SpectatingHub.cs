using AngbandOS.Web.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents the signal-r hub singleton service to process incoming and outgoing signal-r spectating messages.
    /// This hub is identical to the game-hub, except it allows anonymous requests.
    /// </summary>
    public class SpectatingHub : Hub<ISpectatingHub>
    {
        private readonly GameService GameService;

        public SpectatingHub(
            GameService gameService
        )
        {
            GameService = gameService;
        }

        /// <summary>
        /// Process the incoming web client request to watch a game.
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public void Watch(string watchingConnectionId)
        {
            // Forward the request to the game service.
            GameService.Spectate(Context.ConnectionId, watchingConnectionId);
        }

        /// <summary>
        /// Called when a new spectating window connects to the hub.  This hub doesn't know which game to watch yet, until the spectating window sends the watch message.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous connect.
        /// </returns>
        public override Task OnConnectedAsync()
        {
            // We are not doing anything at this time with the connections.  We should render a list of who is playing though.
            GameService.SpectatingHubConnected(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        /// <summary>
        /// Called when a spectating window disconnects from the hub.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous disconnect.
        /// </returns>
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            GameService.SpectatingHubDisconnected(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
