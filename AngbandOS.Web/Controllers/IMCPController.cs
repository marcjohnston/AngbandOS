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

namespace AngbandOS.Web.Controllers
{
    [Route("apiv1")]
    [ApiController]
    [Produces("application/json")]
    public class IMCPController : ControllerBase
    {
        [HttpGet]
        [Route("ping")]
        [Produces("application/json")]
        [AllowAnonymous]
        public ActionResult<string> Ping()
        {
            return Ok("OK");
        }
    }
}