using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.DataAccess.EntityFramework;
using Banking.DataAccess.EntityFramework.EFImplementaions;
using Banking.DataAccess.Interfaces;
using Banking.Domain;
using Banking.Domain.Options;
using Banking.Services;
using Banking.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Banking.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(options =>
               {
                   options.RequireHttpsMetadata = false;
                   options.SaveToken = true;
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = false,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = appSettingsSection.Get<AppSettingsOptions>().Issuer,
                       ValidAudience = appSettingsSection.Get<AppSettingsOptions>().Audience,
                       IssuerSigningKey =
                           new SymmetricSecurityKey(
                               Encoding.ASCII.GetBytes(appSettingsSection.Get<AppSettingsOptions>().Secret))
                   };
               });

            services.AddDbContext<BankingContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("Default")));

            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<IRepository<BankAccount>, BankAccountRepository>();
            services.AddScoped<IRepository<BankCard>, BankCardRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Service>, ServiceRepository>();
            services.AddScoped<IRepository<Domain.ServiceProvider>, ServiceProviderRepository>();

            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
