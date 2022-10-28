using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;
using AngbandOS.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents the signal-r hub singleton service to process incoming and outgoing signal-r spectating messages.
    /// This hub is identical to the game-hub, except it allows anonymous requests.
    /// </summary>
    public class SpectatorsHub : Hub<ISpectatorsHub>
    {
        private readonly GameService GameService;
        private readonly UserManager<ApplicationUser> UserManager;

        public SpectatorsHub(
            GameService gameService,
            UserManager<ApplicationUser> userManager
        )
        {
            GameService = gameService;
            UserManager = userManager;
        }

        /// <summary>
        /// Process the incoming web client request to watch a game.
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public void Watch(string watchingConnectionId)
        {
            // Forward the request to the game service.
            GameService.Watch(Context.ConnectionId, watchingConnectionId);
        }

        public override Task OnConnectedAsync()
        {
            // We are not doing anything at this time with the connections.  We should render a list of who is playing though.
            HttpTransportType? transportType = Context.Features.Get<IHttpTransportFeature>()?.TransportType;
            GameService.SpectatorsHubConnected(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            GameService.SpectatorsHubDisconnected(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
