using AngbandOS.Interface;
using AngbandOS.PersistentStorage;
using AngbandOS.Web.Data;
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
        private readonly GameService GameService;
        //private SqlPersistentStorage SqlPersistentStorage { get; }
        private readonly string ConnectionString;

        public GamesController(IConfiguration config, GameService gameService)
        {
            //SqlPersistentStorage = sqlPersistentStorage;
            GameService = gameService;
            ConnectionString = config["ConnectionString"];
        }

        [Route("{username}")]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<SavedGameDetails> GetSavedGames([FromRoute] string username)
        {
            return Ok(SavedGames.List(ConnectionString, username));
        }
    }
}
