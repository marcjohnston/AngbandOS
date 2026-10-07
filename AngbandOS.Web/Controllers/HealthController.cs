using AngbandOS.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngbandOS.Web.Controllers
{
    [Route("apiv1")]
    [ApiController]
    [Produces("application/json")]
    public class HealthController : ControllerBase
    {
        private readonly ApplicationDbContext DbContext;

        public HealthController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        [Route("ping")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Health()
        {
            bool dbOk = await DbContext.Database.CanConnectAsync(HttpContext.RequestAborted);
            return dbOk ? Ok("ok") : StatusCode(503, "unavailable");
        }
    }
}