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
    [Route("apiv1")]
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

        [HttpGet]
        [Route("games")]
        [Produces("application/json")]
        [AllowAnonymous]
        public ActionResult<ActiveGameDetails[]> GetActiveGames()
        {
            ActiveGameDetails[] activeGames = GameService.GetActiveGames();
            return Ok(activeGames);
        }

        [HttpGet]
        [Route("saved-games")]
        [Produces("application/json")]
        [Authorize]
        public async Task<ActionResult<SavedGameDetails>> GetSavedGames()
        {
            string? emailAddress = User?.FindFirst(ClaimTypes.Email)?.Value;
            if (emailAddress == null)
                return Unauthorized();

            ApplicationUser? user = await UserManager.FindByEmailAsync(emailAddress);
            if (user == null)
                return Unauthorized();
            return Ok(SavedGames.List(ConnectionString, user.Id));
        }
    }
}
