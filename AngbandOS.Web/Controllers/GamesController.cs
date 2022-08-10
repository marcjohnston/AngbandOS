using Cthangband;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngbandOS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GamesController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<string> PostNewGame([FromBody] PostNewGame postNewGame)
        {
            string guid = GameServer.NewGame();
            return Ok(Guid.NewGuid().ToString());
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
