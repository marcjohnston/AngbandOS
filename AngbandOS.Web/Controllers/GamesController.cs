using AngbandOS.Core.Interface;
using AngbandOS.PersistentStorage;
using AngbandOS.Web.Hubs;
using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

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

        //#region Configuration Designer
        [HttpGet]
        [Route("configurations/default")]
        [Produces("application/json")]
        [ResponseCache(Duration = 600, Location = ResponseCacheLocation.Any, NoStore = false)]
        public ActionResult<GameConfiguration> GetGameConfiguration()
        {
            string connectionString = Configuration["ConnectionString"];

            // Create a new instance of the Sql persistent storage so that concurrent games do not interfere with each other.
            IGameConfigurationPersistentStorage gameConfigurationPersistentStorage = new SqlGameConfigurationPersistentStorage(connectionString);

            GameConfiguration gameConfiguration = gameConfigurationPersistentStorage.LoadConfiguration(null, "");

            // We do not want the clients to have the properties automatically camel-cased.  They won't be aligned with the Metadata.  We also have to ensure tuple-fields get serialized.
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = null,
                IncludeFields = true
            };

            return new JsonResult(gameConfiguration, jsonOptions);
        }

        //[HttpGet]
        //[Route("configuration/{guid}")]
        //[Produces("application/json")]
        //public async Task<ActionResult<GameConfiguration>> GetConfiguration(string userId, string guid)
        //{
        //    string? emailAddress = User?.FindFirst(ClaimTypes.Email)?.Value;
        //    if (emailAddress == null)
        //        return Unauthorized();

        //    ApplicationUser? user = await UserManager.FindByEmailAsync(emailAddress);
        //    if (user == null)
        //        return Unauthorized();
        //    SavedGameDetails[] updatedSavedGameList = await PersistentStorage.ListAsync(user.Id);

        //    return GameService.GetGameConfiguration(userId, guid);

        //    // Create a new instance of the Sql persistent storage so that concurrent games do not interfere with each other.
        //    ICorePersistentStorage corePersistentStorage = new SqlCorePersistentStorage(ConnectionString, userId, guid);

        //    return GameConfiguration.LoadConfiguration(corePersistentStorage);
        //}

        [HttpGet]
        [Route("configurations/metadata")]
        [Produces("application/json")]
        [AllowAnonymous]
        public ActionResult<PropertyMetadata[]> GetGameConfigurationMetadata()
        {
            PropertyMetadata[] metadata = GameConfiguration.Metadata;
            return Ok(metadata);
        }
        //#endregion
    }
}
