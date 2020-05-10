using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace First.Net.Core.Api.InstallServices
{
    public static class InstallJWTAttributes
    {
        public static void InstallJWTAuthParams(this IServiceCollection services, IConfiguration Configuration)
        {
            //the secret Key
            string secretKey = "Hi_ThiS_is_my_sEcRet_Key";
            //Create symetric key 
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(op =>
                {
                    op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,

                        ValidIssuer = Configuration.GetSection("JWTConfiguration").GetSection("Issuer").Value,
                        ValidAudience = Configuration.GetSection("JWTConfiguration").GetSection("Audience").Value,
                        IssuerSigningKey = symetricSecurityKey,
                        LifetimeValidator = LifeTimeValidatorService
                    };
                });
        }

        private static bool LifeTimeValidatorService(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.Now < expires.Value.ToLocalTime()) return true;
            }
            return false;
        }
    }
}
