
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

    public class DbPingController : ControllerBase
    {
        private readonly ApplicationDbContext DbContext;

        public DbPingController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        [Route("db-ping")]
        [Produces("application/json")]
        [AllowAnonymous]

        public async Task<ActionResult<string>> DbPing()
        {
            try
            {
                bool canConnect = await DbContext.Database.CanConnectAsync();
                if (canConnect)
                {
                    return StatusCode(200, "pk");
                }
                else
                {
                    return StatusCode(503, "unavailable");
                }
            }
            catch (Exception)
            {
                return StatusCode(503, "unavailable");
            }
        }
    }
}
