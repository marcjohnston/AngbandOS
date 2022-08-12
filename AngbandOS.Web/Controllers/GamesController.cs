using AngbandOS.Web.Hubs;
using Cthangband;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AngbandOS.Web.Controllers
{
    [Route("apiv1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService GameService;

        public GamesController(IGameService gameService)
        {
            GameService = gameService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<string> PostNewGame([FromBody] PostNewGame postNewGame)
        {
            // Request a new game from the game server and return the guid to the client.
            string guid = GameService.NewGame();
            return Ok(guid);
        }

        [Route("{guid}")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<string> GetExistingGameToContinue(string guid)
        {
            return Ok();
        }
    }
}
