using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddAuthentication()
    .AddJwtBearer("IdentityApiKey", x =>
    {
        x.Authority = "https://localhost:5203"; // IDENTITY SERVER URL
        //x.RequireHttpsMetadata = false;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

builder.Services.AddOcelot();

var app = builder.Build();


app.UseRouting();
app.MapControllers();

await app.UseOcelot();

app.Run();
