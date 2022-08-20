using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using AngbandOS.Web.Data;
using AngbandOS.Web.Models;
using AngbandOS.Web.Hubs;
using Microsoft.AspNetCore.Identity.UI.Services;
using AngbandOS.Web;
using AngbandOS.Web.TemplateProcessing;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionString"]; // Connection string is stored as a user secret

builder.Services.AddSignalR();

builder.Services.AddSingleton(typeof(GameService), typeof(GameService)); // Maintains active games.  Interface excluded.
builder.Services.AddScoped(typeof(TemplateProcessor), typeof(TemplateProcessor)); // Template macro processor
builder.Services.AddTransient<IEmailSender, EmailSender>(); // Email sender

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("RequireConfirmedAccount"))
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
