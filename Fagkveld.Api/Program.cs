using Application;
using Application.Common.Interfaces;
using Fagkveld.Api;
using Fagkveld.Api.Services;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);

builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fagkveld Api");
    c.OAuthClientId(app.Configuration.GetSection("Swagger").GetValue<string>("ClientId"));
    c.OAuthAppName("Fagkveld Api");
    c.RoutePrefix = string.Empty;
    c.EnableDeepLinking();
    c.OAuthUsePkce();
});

app.UseHttpsRedirection();


app.UseAuthentication();

// Legg til middleware for håndtering av tenants...
//app.UseMiddleware<TenantAuthorizationMiddleWare>();
app.UseAuthorization();

app.MapControllers();

app.Run();
