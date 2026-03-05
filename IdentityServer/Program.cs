using Duende.IdentityServer.Models;
using IdentityServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();    
builder.Services.AddRazorPages();

builder.Services
    .AddIdentityServer(options =>
    {
        options.KeyManagement.Enabled = false;
    })
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddTestUsers(Config.TestUsers)
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
