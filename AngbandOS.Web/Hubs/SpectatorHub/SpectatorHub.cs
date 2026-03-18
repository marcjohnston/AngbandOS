using AngbandOS.Core.Interface;
using AngbandOS.Web.Services;
using Microsoft.AspNetCore.SignalR;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents the signal-r hub singleton service to process incoming and outgoing signal-r spectating messages.
    /// This hub is identical to the game-hub, except it allows anonymous requests.
    /// </summary>
    public class SpectatorHub : Hub<ISpectatorHubMessages>
    {
        private readonly GameService GameService;

        /// <summary>
        /// The associated viewport for the spectator or null, before the watch command is sent or if the game no longer exists.  The <see cref="Watch(string)"/> method sets this value.
        /// </summary>
        private IViewPort? ViewPort {
            get
            {
                return Context.Items["ViewPort"] as IViewPort;  
            }
            set
            {
                Context.Items["ViewPort"] = value;
            }
        }

        public SpectatorHub(
            GameService gameService
        )
        {
            GameService = gameService;
        }

        #region Incoming messages from the web client
        /// <summary>
        /// Process the incoming web client request to watch a game.
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public void Watch(string watchingConnectionId)
        {
            // Forward the request to the game service.
            ViewPort = GameService.Spectate(Context.ConnectionId, watchingConnectionId);
        }

        /// <summary>
        /// Process a refresh request from the web client.  The client sends this message when the window resizes.
        /// </summary>
        public void Refresh()
        {
            // Ensure there is a viewport.
            if (ViewPort is not null)
            {
                // We need to send the command to the game service, because it has the connections to the game core.
                GameService.RefreshViewPort(Context.ConnectionId, ViewPort);
            }
        }
        #endregion

        #region Connections and disconnections
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
        #endregion
    }
}
