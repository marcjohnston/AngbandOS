using AngbandOS.Web.Hubs;
using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AngbandOS.Web.Controllers
{
    [Route("apiv1")]
    [ApiController]
    [Produces("application/json")]
    public class GamesController : ControllerBase
    {
        private readonly GameService GameService;
        private readonly IWebPersistentStorage PersistentStorage;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly IConfiguration Configuration;

        public GamesController(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IWebPersistentStorage persistentStorage,
            GameService gameService
        )
        {
            GameService = gameService;
            PersistentStorage = persistentStorage;
            UserManager = userManager;
            Configuration = configuration;
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
        public async Task<ActionResult<SavedGameDetails[]>> GetSavedGames()
        {
            string? emailAddress = User?.FindFirst(ClaimTypes.Email)?.Value;
            if (emailAddress == null)
                return Unauthorized();

            ApplicationUser? user = await UserManager.FindByEmailAsync(emailAddress);
            if (user == null)
                return Unauthorized();
            SavedGameDetails[] updatedSavedGameList = await PersistentStorage.ListAsync(user.Id);
            return Ok(updatedSavedGameList);
        }

        [HttpDelete]
        [Route("saved-games/{id}")]
        [Produces("application/json")]
        [Authorize]
        public async Task<ActionResult<SavedGameDetails[]>> DeleteSavedGame([FromRoute] string id)
        {
            string? emailAddress = User?.FindFirst(ClaimTypes.Email)?.Value;
            if (emailAddress == null)
                return Unauthorized();

            ApplicationUser? user = await UserManager.FindByEmailAsync(emailAddress);
            if (user == null)
                return Unauthorized();

            if (await PersistentStorage.DeleteAsync(id, user.Id))
            {
                SavedGameDetails[] savedGames = await PersistentStorage.ListAsync(user.Id);
                return Ok(savedGames);
            }
            else
                return NotFound();
        }

        [HttpDelete]
        [Route("games/{connectionId}")]
        [Produces("application/json")]
        [Authorize]
        public ActionResult KillActiveGame([FromRoute] string connectionId)
        {
            string customRoleClaimType = Configuration["CustomRoleClaimType"];
            bool isAdministrator = User == null ? false : User.HasClaim(customRoleClaimType, "administrator");
            if (!isAdministrator)
                return Unauthorized();

            if (GameService.KillGame(connectionId))
                return Ok();
            else
                return Conflict();
        }
    }
}
