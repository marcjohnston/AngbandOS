using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents the signal-r hub singleton service to process incoming and outgoing signal-r game messages.
    /// </summary>
    public class ServiceHub : Hub<IServiceHub>
    {
        public ServiceHub(
        )
        {
        }

        public override Task OnConnectedAsync()
        {
            // We are not doing anything at this time with the connections.  We should render a list of who is playing though.
            HttpTransportType? transportType = Context.Features.Get<IHttpTransportFeature>()?.TransportType;
            return base.OnConnectedAsync();
        }
    }
}
