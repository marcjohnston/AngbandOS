using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using AngbandOS.Web.Data;
using AngbandOS.Web.Models;
using Microsoft.AspNetCore.SignalR;
using AngbandOS.Web.Hubs;
using AngbandOS.Interface;
using AngbandOS.PersistentStorage;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

builder.Services.AddSingleton(typeof(IGameService), typeof(GameService)); // Maintains active games.
builder.Services.AddSingleton(typeof(SqlPersistentStorage), typeof(AngbandOSSql)); // Controllers that need access to the database can request SqlPersistentStorage and retrieve a scoped AngbandOSSql object.

// Add services to the container.
var connectionString = builder.Configuration["ConnectionString"]; // Connection string is stored as a user secret
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // Connection string is stored in the appsettings.json file, if desired.

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

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
app.UseIdentityServer();
app.UseAuthorization();

app.MapHub<GameHub>("/apiv1/hub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html");;

app.Run();
