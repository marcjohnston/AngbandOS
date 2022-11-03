using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;
using AngbandOS.Web.TemplateProcessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AngbandOS.PersistentStorage.Sql.Entities;

namespace AngbandOS.Web.Controllers
{
    [Route("apiv1/preferences")]
    public class PreferencesController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly IWebPersistentStorage WebPersistentStorage;

        public PreferencesController(IConfiguration config,
          UserManager<ApplicationUser> userManager,
          IWebPersistentStorage webPersistentStorage)
        {
            Configuration = config;
            UserManager = userManager;
            WebPersistentStorage = webPersistentStorage;
        }

        [HttpGet]
        [Authorize]
        [Route("{emailAddress}")]
        [Produces("application/json")]
        public async Task<ActionResult<GetUserPreferences>> GetUserPreferences(string emailAddress)
        {
            ApplicationUser? appUser = await UserManager.FindByEmailAsync(emailAddress);
            if (appUser == null)
                return base.StatusCode((int)HttpStatusCode.Forbidden);

            UserSettingsDetails? userSettings = await WebPersistentStorage.GetPreferences(appUser.Id);
            return new GetUserPreferences()
            {
                FontName = userSettings.FontName,
                FontSize = userSettings.FontSize,
                F1Macro = userSettings.F1Macro,
                F2Macro = userSettings.F2Macro,
                F3Macro = userSettings.F3Macro,
                F4Macro = userSettings.F4Macro,
                F5Macro = userSettings.F5Macro,
                F6Macro = userSettings.F6Macro,
                F7Macro = userSettings.F7Macro,
                F8Macro = userSettings.F8Macro,
                F9Macro = userSettings.F9Macro,
                F10Macro = userSettings.F10Macro,
                F11Macro = userSettings.F11Macro,
                F12Macro = userSettings.F12Macro
            };
        }

        [HttpPut]
        [Authorize]
        [Route("{emailAddress}")]
        [Produces("application/json")]
        public async Task<ActionResult<GetUserPreferences>> PutUserPreferences(string emailAddress, PutUserPreferences userSettings)
        {
            ApplicationUser? appUser = await UserManager.FindByEmailAsync(emailAddress);
            if (appUser == null)
                return base.StatusCode((int)HttpStatusCode.Forbidden);

            UserSettingsDetails userSettingsDetails = new UserSettingsDetails()
            {
                FontName = userSettings.FontName,
                FontSize = userSettings.FontSize,
                F1Macro = userSettings.F1Macro,
                F2Macro = userSettings.F2Macro,
                F3Macro = userSettings.F3Macro,
                F4Macro = userSettings.F4Macro,
                F5Macro = userSettings.F5Macro,
                F6Macro = userSettings.F6Macro,
                F7Macro = userSettings.F7Macro,
                F8Macro = userSettings.F8Macro,
                F9Macro = userSettings.F9Macro,
                F10Macro = userSettings.F10Macro,
                F11Macro = userSettings.F11Macro,
                F12Macro = userSettings.F12Macro
            };

            UserSettingsDetails? updatedUserSettings = await WebPersistentStorage.WritePreferences(appUser.Id, userSettingsDetails);
            return new GetUserPreferences()
            {
                FontName = userSettings.FontName,
                FontSize = userSettings.FontSize,
                F1Macro = userSettings.F1Macro,
                F2Macro = userSettings.F2Macro,
                F3Macro = userSettings.F3Macro,
                F4Macro = userSettings.F4Macro,
                F5Macro = userSettings.F5Macro,
                F6Macro = userSettings.F6Macro,
                F7Macro = userSettings.F7Macro,
                F8Macro = userSettings.F8Macro,
                F9Macro = userSettings.F9Macro,
                F10Macro = userSettings.F10Macro,
                F11Macro = userSettings.F11Macro,
                F12Macro = userSettings.F12Macro
            };
        }
    }
}
