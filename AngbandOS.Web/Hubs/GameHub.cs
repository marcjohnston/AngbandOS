using AngbandOS;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using AngbandOS.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace AngbandOS.Web.Hubs
{
    [Authorize]
    /// <summary>
    /// Represents the signal-r hub to process the following incoming and outgoing signal-r game messages:
    /// - Play a game
    /// - Keypressed from client
    /// - Outgoing print, clear, sound, background and game-over messages.
    /// </summary>
    public class GameHub : Hub<IGameHub>
    {
        private readonly GameService GameService;
        private readonly UserManager<ApplicationUser> UserManager;

        public GameHub(
            GameService gameService,
            UserManager<ApplicationUser> userManager
        )
        {
            GameService = gameService;
            UserManager = userManager;
        }

        ///// <summary>
        ///// Process the incoming web client request to play a game.
        ///// </summary>
        ///// <param name="guid">The unique identifier for the game to be played.  Must be owned by the user.  Null, to start a new game.</param>
        ///// <returns></returns>
        public async Task Play(string guid)
        {
            // We need to ensure the user is authenticated.
            string? emailAddress = Context.User?.FindFirst(ClaimTypes.Email)?.Value;
            ApplicationUser? user = await UserManager.FindByEmailAsync(emailAddress);

            if (user.Id != null)
            {
                await GameService.PlayAsync(Context, user.Id, guid, Context.ConnectionId, user.UserName);
            }
        }

        /// <summary>
        /// Process an incoming message from a web client of a keypress.
        /// </summary>
        /// <returns></returns>
        public void Keypressed(string keys)
        {
            // Route this keypress message to the correct game console.
            GameService.Keypressed(Context.ConnectionId, keys);
        }

        public async override Task OnConnectedAsync()
        {
            // We are not doing anything at this time with the connections.  We should render a list of who is playing though.
            HttpTransportType? transportType = Context.Features.Get<IHttpTransportFeature>()?.TransportType;
            string? emailAddress = Context.User?.FindFirst(ClaimTypes.Email)?.Value;
            ApplicationUser? user = await UserManager.FindByEmailAsync(emailAddress);
            await GameService.GameHubConnectedAsync(Context.ConnectionId, user.UserName);
        }

        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            await GameService.GameHubDisconnectedAsync(Context.ConnectionId);
        }
    }
}
