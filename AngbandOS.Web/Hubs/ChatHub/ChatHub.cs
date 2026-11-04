using AngbandOS.Web.Interface;
using AngbandOS.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents the signal-r hub to process the ability to receive, send and delete messages, which require authentication.  The reception of messages also retrieves direct messages because the
    /// user is authenticated (so we know who they are).
    /// </summary>
    [Authorize]
    public class ChatHub : Hub<IChatHubMessages>
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly IWebPersistentStorage WebPersistentStorage;
        private readonly IHubContext<ServiceHub, IServiceHubMessages> ServiceHub;
        private readonly IConfiguration Configuration;
        private readonly GameService GameService;

        public ChatHub(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IHubContext<ServiceHub, IServiceHubMessages> serviceHub,
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

        public async Task DeleteMessage(int messageId)
        {
            // Ensure there is a user and that the message is not empty.
            if (Context.User == null)
            {
                return;
            }

            // Restricted to admins.
            string customRoleClaimType = Configuration["CustomRoleClaimType"];
            if (Context.User.HasClaim(customRoleClaimType, "administrator"))
            {
                await WebPersistentStorage.DeleteMessageAsync(messageId);                
                // We need to force a refresh of all chat clients.
                //RefreshChat(oldestDownloadedMessageId);
                //ChatMessage[] chatMessages = await GameService.GetChatMessagesAsync(Context.ConnectionId, oldestDownloadedMessageId);
                //IChatHub chatHub = Clients.Client(Context.ConnectionId);
                //await chatHub.ChatRefreshed(chatMessages.ToArray());
            }
        }

        public async Task SendMessage(string? toUsername, string message)
        {
            // Ensure there is a user and that the message is not empty.
            if (message.Length == 0 || Context.User == null)
            {
                return;
            }

            bool success = await GameService.WriteMessageAsync(Context.User, toUsername, message, MessageTypeEnum.UserMessage, null);
            if (!success)
            {
                await Clients.Client(Context.ConnectionId).MessageFailed();
            }
        }

        public async Task RefreshChat(int? oldestDownloadedMessageId)
        {
            //gets up to 50 messages and returns  hasMoreMessages = true if there are additonal messages on the database
            (ChatMessage[] chatMessages, bool hasMoreMessages) = await GameService.GetChatMessagesAsync(Context.ConnectionId, oldestDownloadedMessageId);

            // Get the hub for the currently connected client.
            IChatHubMessages chatHub = Clients.Client(Context.ConnectionId);

            // Send the response.
            await chatHub.ChatRefreshed(chatMessages, hasMoreMessages);
        }


        public async override Task OnConnectedAsync()
        {
            IChatHubMessages chatHub = Clients.Client(Context.ConnectionId);
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
