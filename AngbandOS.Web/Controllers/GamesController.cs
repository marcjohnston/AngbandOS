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

        public GamesController(
            IConfiguration config,
            GameService gameService
        )
        {
            GameService = gameService;
            ConnectionString = config["ConnectionString"];
        }

        private string? GetUserIdentifier => User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<SavedGameDetails> GetSavedGames()
        {
            string? userIdentifier = GetUserIdentifier;
            if (userIdentifier != null)
                return Ok(SavedGames.List(ConnectionString, userIdentifier));
            else
                return Unauthorized();
        }
    }
}
