using Cthangband;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;

namespace AngbandOS.Web.Hubs
{
    public class GameHub : Hub<IGameHub>
    {
        private readonly IGameService GameService;

        public GameHub(IGameService gameService)
        {
            GameService = gameService;
        }

        ///// <summary>
        ///// Process the incoming web client request to play a game.
        ///// </summary>
        ///// <param name="guid"></param>
        ///// <returns></returns>
        public void Play(string guid)
        {
            GameService.Play(guid, Context.ConnectionId);
        }

        /// <summary>
        /// Process an incoming message from a web client of a keypress.
        /// </summary>
        /// <returns></returns>
        public void Keypressed(string keys)
        {
            GameService.Keypressed(Context.ConnectionId, keys);
        }

        public override Task OnConnectedAsync()
        {
            // We are not doing anything at this time with the connections.  We should render a list of who is playing though.
            HttpTransportType? transportType = Context.Features.Get<IHttpTransportFeature>()?.TransportType;
            return base.OnConnectedAsync();
        }
    }
}
