using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Users.Model;
using Users.Model.Repository;
using Users.Model.UnitOfWork;

namespace Users.Services
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
        {
            var tokenKey = Encoding.UTF8.GetBytes("ABNM YE KJLK FD OPIL KLM AERIFY ERT OOKENS, REPLACE AB POIN YOUN OWN SECRET, IT HTR PO RET STWINC");
            var encryptionkey = Encoding.UTF8.GetBytes("qwsadfrewtyh4532");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                      .AddJwtBearer(x =>
                      {
                          x.RequireHttpsMetadata = false;
                          x.SaveToken = true;
                          x.TokenValidationParameters = new TokenValidationParameters
                          {
                              RequireExpirationTime = true,
                              ValidateLifetime = true,
                              ValidateIssuerSigningKey = true,
                              IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                              ValidateIssuer = false,
                              ValidateAudience = false,
                              TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)

                          };
                      });
            return services;

        }

        public static void AddCustomApplicationServices(this IServiceCollection services)
        {

            services.AddTransient<UserDBContext>();
            services.AddTransient<ICreateToken,CreateToken>();
            services.AddTransient<UsersRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

        }
    }
}
