using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme",options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.RequireHttpsMetadata = false;
    options.Audience = "ResourceOcelot";
});

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

//builder.Configuration.SetBasePath(builder.Environment.ContentRootPath).AddOcelot();
builder.Services.AddOcelot(configuration);

var app = builder.Build();

await app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
