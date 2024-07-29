using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Identity.Interfaces;
using Infrastructure.Persistence.DbContexts;
using Domain.Interfaces.Repositories;
using Domain.Repositories;
using Infrastructure.Persistence.Repositories;
using Application.Features.Identity.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure
{
    public static class ServiceCollection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserContext, UserContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<IdentityConfig>(configuration.GetSection("Identity"));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.User.RequireUniqueEmail = true;
            });

            var identityConfig = configuration.GetSection("Identity").Get<IdentityConfig>();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(config =>
                {
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = identityConfig.Issuer,
                        ValidAudience = identityConfig.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identityConfig.Secret))
                    };
                });
        }
    }
}