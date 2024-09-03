using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace TaskManagement.Api.AppStart;

public static class JwtConfigurator
{
    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure JWT authentication
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

        // Configure authorization policies
        services.AddAuthorization(options =>
        {
            options.AddPolicy("ManagerPolicy", policy =>
                policy.RequireRole("Manager"));

            options.AddPolicy("AdminPolicy", policy =>
                policy.RequireRole("Admin"));
        });
    }
}