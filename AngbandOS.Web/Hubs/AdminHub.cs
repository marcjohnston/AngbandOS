using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents the signal-r hub to process the following incoming and outgoing signal-r chat messages:
    /// - Refresh
    /// - SendMessage
    /// </summary>
    [Authorize]
    public class AdminHub : Hub<IAdminHub>
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly IWebPersistentStorage WebPersistentStorage;
        private readonly IHubContext<ServiceHub, IServiceHub> ServiceHub;
        private readonly IConfiguration Configuration;
        private readonly GameService GameService;

        public AdminHub(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IHubContext<ServiceHub, IServiceHub> serviceHub,
            IWebPersistentStorage webPersistentStorage,
            GameService gameService
        )
        {
            GameService = gameService;
            WebPersistentStorage = webPersistentStorage;
            UserManager = userManager;
            ServiceHub = serviceHub;
            Configuration = configuration;
        }

        public void UpdateHubConnections()
        {
            IAdminHub adminHub = Clients.Client(Context.ConnectionId);
            HubConnections hubConnections = GameService.GetConnections();
            adminHub.HubConnectionsUpdated(hubConnections);
        }

        public async override Task OnConnectedAsync()
        {
            // We are not doing anything at this time with the connections.  We should render a list of who is playing though.
            HttpTransportType? transportType = Context.Features.Get<IHttpTransportFeature>()?.TransportType;
            string? emailAddress = Context.User?.FindFirst(ClaimTypes.Email)?.Value;
            ApplicationUser? user = await UserManager.FindByEmailAsync(emailAddress);
            GameService.AdminHubConnected(Context.ConnectionId, user.UserName);
        }

        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            GameService.AdminHubDisconnected(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
