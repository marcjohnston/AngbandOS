using AngbandOS.PersistentStorage;
using AngbandOS.Web;
using AngbandOS.Web.Data;
using AngbandOS.Web.Hubs;
using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;
using AngbandOS.Web.TemplateProcessing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionString"]; // Connection string is stored as a user secret

builder.Services.AddSignalR();

builder.Services.AddSingleton(typeof(GameService), typeof(GameService)); // Maintains active games.  Interface excluded.
builder.Services.AddScoped(typeof(TemplateProcessor), typeof(TemplateProcessor)); // Template macro processor
builder.Services.AddScoped(typeof(IWebPersistentStorage), typeof(SqlWebPersistentStorage)); // Persistent storage driver
builder.Services.AddTransient<IEmailSender, EmailSender>(); // Email sender

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var secret = builder.Configuration["Jwt:Secret"];
var key = Encoding.ASCII.GetBytes(secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer((jwtBearerOptions) =>
{
    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
    // We have to hook the OnMessageReceived event in order to
    // allow the JWT authentication handler to read the access
    // token from the query string when a WebSocket or 
    // Server-Sent Events request comes in.
    jwtBearerOptions.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            var authToken = context.Request.Headers["Authorization"].ToString();

            var token = !string.IsNullOrEmpty(accessToken) ? accessToken.ToString() : !string.IsNullOrEmpty(authToken) ? authToken.Substring(7) : String.Empty;

            var path = context.HttpContext.Request.Path;

            // If the request is for our hub...
            if (!string.IsNullOrEmpty(token) && (path.StartsWithSegments("/apiv1/chat-hub") || path.StartsWithSegments("/apiv1/service-hub") || path.StartsWithSegments("/apiv1/game-hub") || path.StartsWithSegments("/apiv1/spectators-hub") || path.StartsWithSegments("/apiv1/admin-hub")))
            {
                // Read the token out of the query string
                context.Token = token;
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 7;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = false; // We do not require the confirmed email but the user will not have edit rights.
    options.SignIn.RequireConfirmedAccount = false; // This is a newer integration point that we do not need either.
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<GameHub>("/apiv1/game-hub"); // Processes actual game play
app.MapHub<ServiceHub>("/apiv1/service-hub"); // Processes active game list
app.MapHub<SpectatorsHub>("/apiv1/spectators-hub"); // Processes spectating games
app.MapHub<ChatHub>("/apiv1/chat-hub"); // Processes the chat messaging system
app.MapHub<AdminHub>("/apiv1/admin-hub"); // Processes the chat messaging system
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html"); ;

app.Run();
