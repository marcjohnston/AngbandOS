using System.Security.Claims;
using System.Text.Json;
using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface.Configuration;
using AngbandOS.Core.Interface.Metadata;
using AngbandOS.PersistentStorage;
using AngbandOS.Web.Data;
using AngbandOS.Web.Interface;
using AngbandOS.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Health()
        {
            bool dbOk;
            try
            {
                dbOk = await DbContext.Database.CanConnectAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database health check failed: {ex}");
                dbOk = false;
            }
            return dbOk ? Ok("ok") : StatusCode(503, "unavailable");
        }
    }
}