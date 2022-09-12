using AngbandOS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AngbandOS.Web.TemplateProcessing;
using System.Net;

namespace AngbandOS.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("apiv1/accounts")]
    public class AccountsCollectionController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> SignInManager;
        private readonly IEmailSender EmailSender;
        private readonly TemplateProcessor TemplateProcessor;

        /// <summary>
        /// Creates a new instance of the controller.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="signalRMessageHub"></param>
        /// <param name="siteStatusProvider"></param>
        /// <param name="pushNotificationsService"></param>
        /// <param name="profilingProvider"></param>
        /// <param name="loggingProvider"></param>
        /// <param name="mailService"></param>
        public AccountsCollectionController(IConfiguration config,
          UserManager<ApplicationUser> userManager,
          TemplateProcessor templateProcessor,
          SignInManager<ApplicationUser> signInManager,
          IEmailSender emailSender)
        {
            Configuration = config;
            UserManager = userManager;
            TemplateProcessor = templateProcessor;
            SignInManager = signInManager;
            EmailSender = emailSender;
        }

        private bool IsValidEmailAddress(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        public async Task<ActionResult<string[]>> RegisterAsync([FromBody] PostAccount postUser)
        {
            if (postUser == null)
                return BadRequest("The user to post was not supplied or parse correctly.");

            if (postUser.Username.Length < 5 || postUser.Username.Length > 15 || !char.IsLetter(postUser.Username[0]) || !postUser.Username.Substring(1).All(char.IsLetterOrDigit))
                return BadRequest("Invalid username.");

            if (!IsValidEmailAddress(postUser.EmailAddress))
                return BadRequest("Invalid email address.");

            // Create a user to add to the ASP.NET Core Identity.
            ApplicationUser newUser = new ApplicationUser()
            {
                UserName = postUser.Username,
                Email = postUser.EmailAddress
            };

            // Create the user.
            IdentityResult result = await UserManager.CreateAsync(newUser, postUser.Password);

            // If it failed, throw.
            if (!result.Succeeded)
            {
                // We may have a special case that we can to clean up. Since the email addresses are used as usernames, we want to hide the concept of usernames
                // from the UI.  If there are errors relating to the "username" ... then remove the error.  There "should" be a corresponding error relating to 
                // the email address.
                string[] errors = result.Errors.Select(_error => _error.Description).ToArray();

                // Filter any error message with the term "username" from the errors.
                //errors = errors.Where(_error => !_error.Contains("user name", System.StringComparison.OrdinalIgnoreCase)).ToArray();
                return Conflict(errors);
            }

            return Ok(new string[] { });
        }

        private string GenerateJSONWebToken(ApplicationUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Generate the claims that we need to include in the JWT.
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("email", userInfo.Email));
            claims.Add(new Claim("email_verified", userInfo.EmailConfirmed ? "true" : "false"));
            claims.Add(new Claim("username", userInfo.UserName));

            var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
              Configuration["Jwt:Issuer"],
              claims.ToArray(),
              expires: DateTime.Now.AddSeconds(86400),
              signingCredentials: credentials);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            return jwtSecurityTokenHandler.WriteToken(token);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("{emailAddress}/authentication")]
        [Produces("application/json")]
        public async Task<ActionResult<LoginResponse>> LoginAsync([FromRoute] string emailAddress, [FromBody] PostAuthentication postAuthentication)
        {
            if (postAuthentication == null)
                return BadRequest("The authentication request to post was not supplied or parse correctly.");

            if (postAuthentication.Password != null)
            {
                ApplicationUser? appUser = await UserManager.FindByEmailAsync(emailAddress);
                if (appUser != null)
                {
                    await SignInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await SignInManager.PasswordSignInAsync(appUser, postAuthentication.Password, false, false);
                    if (result.Succeeded)
                    {
                        string tokenString = GenerateJSONWebToken(appUser);
                        return Ok(new LoginResponse()
                        {
                            JwtToken = tokenString
                        });
                    }
                }
            }
            return NotFound();
        }

        [HttpGet]
        [Authorize]
        [Route("verification")]
        [Produces("application/json")]
        public async Task<ActionResult> SendConfirmationEmailAsync()
        {
            string? emailAddress = User?.FindFirst(ClaimTypes.Email)?.Value;
            if (emailAddress == null)
                return Unauthorized();

            ApplicationUser currentUser = await UserManager.FindByEmailAsync(emailAddress);

            // Create an email confirmation token and send it to the user.
            string token = await UserManager.GenerateEmailConfirmationTokenAsync(currentUser);

            // Create an email to send to the user.
            string confirmationLink = $"{Request.Scheme}://{Request.Host}/accounts/confirm?token={WebUtility.UrlEncode(token)}&emailAddress={WebUtility.UrlEncode(emailAddress)}";
            Dictionary<string, string> macros = new Dictionary<string, string>();
            macros.Add("email-confirmation-url", confirmationLink);
            string htmlDocument = TemplateProcessor.GenerateContent("ConfirmEmail", macros);

            await EmailSender.SendEmailAsync(currentUser.Email, "AngbandOS Confirm Email", htmlDocument);

            // The account was created and there was no error sending email.
            return Ok();
        }

        [HttpPut]
        [Authorize]
        [Route("verification")]
        [Produces("application/json")]
        public async Task<ActionResult<string[]?>> VerifyAccountAsync([FromBody] VerifyAccount verifyAccount)
        {
            if (verifyAccount == null)
                return BadRequest("The user verification to put was not supplied or parse correctly.");

            // Ensure the user performing the confirmation is the currently logged on user.
            if (User == null)
                return base.StatusCode((int)HttpStatusCode.Forbidden);

            string? emailAddress = User?.FindFirst(ClaimTypes.Email)?.Value;
            if (emailAddress == null)
                return Unauthorized();
            ApplicationUser user = await UserManager.FindByEmailAsync(emailAddress);

            IdentityResult result = await UserManager.ConfirmEmailAsync(user, verifyAccount.Token);
            if (!result.Succeeded)
                return BadRequest(new string?[] { result.Errors.FirstOrDefault()?.Description });

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{emailAddress}/password")]
        [Produces("application/json")]
        public async Task<ActionResult> SendPasswordRecoveryToken([FromRoute] string emailAddress)
        {
            ApplicationUser? appUser = await UserManager.FindByEmailAsync(emailAddress);

            // If the user does not exist, do not inform the client.  This is an anonymous call.
            if (appUser == null)
              return Ok();

            string token = await UserManager.GeneratePasswordResetTokenAsync(appUser);

            // Create an email to send to the user.
            string resetPasswordLink = $"{Request.Scheme}://{Request.Host}/accounts/reset-password?token={WebUtility.UrlEncode(token)}&emailAddress={WebUtility.UrlEncode(emailAddress)}";
            Dictionary<string, string> macros = new Dictionary<string, string>();
            macros.Add("reset-password-url", resetPasswordLink);
            string htmlDocument = TemplateProcessor.GenerateContent("ResetPassword", macros);
            await EmailSender.SendEmailAsync(appUser.Email, "AngbandOS Reset Password", htmlDocument);

            // The account was created and there was no error sending email.
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="resetPasswordRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("{emailAddress}/password")]
        [Produces("application/json")]
        public async Task<ActionResult> ResetPassword([FromRoute] string emailAddress, [FromBody] ResetPassword resetPasswordRequest)
        {
            if (resetPasswordRequest == null)
                return BadRequest("The password reset request to post was not supplied or parsed correctly.");
            else
            {
                ApplicationUser? appUser = await UserManager.FindByEmailAsync(emailAddress);
                if (appUser != null)
                {
                    IdentityResult result = await UserManager.ResetPasswordAsync(appUser, resetPasswordRequest.ResetPasswordToken, resetPasswordRequest.NewPassword);
                    if (result.Succeeded)
                        return Ok();
                }
                return base.StatusCode((int)HttpStatusCode.Forbidden);
            }
        }
    }
}
