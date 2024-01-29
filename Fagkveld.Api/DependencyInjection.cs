using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

namespace Fagkveld.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddMicrosoftIdentityWebApiAuthentication(configuration);
        services.AddHttpContextAccessor();
        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddControllers();
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fagkveld Api", Version = "v1" });

            c.AddSecurityDefinition("Azure AD", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,

                Flows = new OpenApiOAuthFlows
                {
                    // TODO: Sett opp pålogging mot api'et
                    // Hint: https://learn.microsoft.com/en-us/entra/identity-platform/msal-client-application-configuration
                    //Implicit =
                }
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Azure AD" }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}
