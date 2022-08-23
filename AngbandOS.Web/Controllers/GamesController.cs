using AngbandOS.Interface;
using AngbandOS.PersistentStorage;
using AngbandOS.Web.Data;
using AngbandOS.Web.Hubs;
using AngbandOS.Web.Models;
using Cthangband;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace AngbandOS.Web.Controllers
{
    [Route("apiv1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GamesController : ControllerBase
    {
        private readonly GameService GameService;
        private readonly string ConnectionString;
        private readonly UserManager<ApplicationUser> UserManager;

        public GamesController(
            IConfiguration config,
            UserManager<ApplicationUser> userManager,
            GameService gameService
        )
        {
            GameService = gameService;
            UserManager = userManager;
            ConnectionString = config["ConnectionString"];
        }

        private string? GetUserIdentifier => User?.FindFirst(ClaimTypes.Email)?.Value;

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<SavedGameDetails>> GetSavedGames()
        {
            string? emailAddress = GetUserIdentifier;
            ApplicationUser? user = await UserManager.FindByEmailAsync(emailAddress);
            if (user != null)
                return Ok(SavedGames.List(ConnectionString, user.Id));
            else
                return Unauthorized();
        }
    }
}
