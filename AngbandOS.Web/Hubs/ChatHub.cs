using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class ChatHub : Hub<IChatHub>
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly IWebPersistentStorage WebPersistentStorage;
        private readonly IHubContext<ServiceHub, IServiceHub> ServiceHub;
        private readonly IConfiguration Configuration;
        private readonly GameService GameService;

        public ChatHub(
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

        public async Task SendMessage(string? toUsername, string message)
        {
            // Ensure there is a user and that the message is not empty.
            if (message.Length == 0 || Context.User == null)
                return;

            bool success = await GameService.WriteMessageAsync(Context.User, toUsername, message, MessageTypeEnum.UserMessage, null);
            if (!success)
                await Clients.Client(Context.ConnectionId).MessageFailed();
        }

        public async Task RefreshChat(int? endingId)
        {
            ChatMessage[] chatMessages = await GameService.GetChatMessagesAsync(Context.ConnectionId, endingId);

            // Get the hub for the currently connected client.
            IChatHub chatHub = Clients.Client(Context.ConnectionId);

            // Send the response.
            await chatHub.ChatRefreshed(chatMessages.ToArray());
        }


        public async override Task OnConnectedAsync()
        {
            IChatHub chatHub = Clients.Client(Context.ConnectionId);
            string? emailAddress = Context.User.FindFirst(ClaimTypes.Email)?.Value;
            ApplicationUser? appUser = await UserManager.FindByEmailAsync(emailAddress);
            string customRoleClaimType = Configuration["CustomRoleClaimType"];
            if (Context.User.HasClaim(customRoleClaimType, "administrator"))
                GameService.ChatConnected(Context.ConnectionId, new AdministatorChatRecipient(chatHub, appUser.Id, appUser.UserName));
            else
                GameService.ChatConnected(Context.ConnectionId, new UserChatRecipient(chatHub, appUser.Id, appUser.UserName));
            GameService.ChatHubConnected(Context.ConnectionId, appUser.UserName);
            await base.OnConnectedAsync();
        }

        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            GameService.ChatDisconnected(Context.ConnectionId);
            GameService.ChatHubDisconnected(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
