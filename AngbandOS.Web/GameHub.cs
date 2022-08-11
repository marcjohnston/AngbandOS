using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;

namespace AngbandOS.Web
{
    public interface IGameHub
    {

    }
    public class GameHub : Hub
    {
        public async Task SendMessage(string user, string message) => await Clients.All.SendAsync("ReceiveMessage", user, message);
        
        public override Task OnConnectedAsync()
        {
            var transportType = Context.Features.Get<IHttpTransportFeature>()?.TransportType;
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
