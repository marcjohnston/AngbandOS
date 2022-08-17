using Cthangband;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AngbandOS.Web.Hubs
{
    [Authorize]
    public class GameHub : Hub<IGameHub>
    {
        private readonly GameService GameService;

        public GameHub(GameService gameService)
        {
            GameService = gameService;
        }

        ///// <summary>
        ///// Process the incoming web client request to play a game.
        ///// </summary>
        ///// <param name="guid">The unique identifier for the game to be played.  Must be owned by the user.  Null, to start a new game.</param>
        ///// <returns></returns>
        public void Play(string guid)
        {
            // We need to ensure the user is authenticated.
            string? userIdentifier = Context.UserIdentifier;

            if (userIdentifier != null)
            {
                GameService.Play(userIdentifier, guid, Context.ConnectionId);
            }
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
