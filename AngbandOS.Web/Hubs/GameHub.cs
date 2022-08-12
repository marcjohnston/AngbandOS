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

        public void Play(string guid)
        {
            GameService.Play(guid, Context.ConnectionId);
        }

        public void Keypressed(string keys)
        {
            GameService.Keypressed(Context.ConnectionId, keys);
        }

        public override Task OnConnectedAsync()
        {
            HttpTransportType? transportType = Context.Features.Get<IHttpTransportFeature>()?.TransportType;
            return base.OnConnectedAsync();
        }
    }
}
