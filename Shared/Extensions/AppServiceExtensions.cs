using BLL.Services.TokenService;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Helpers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Repository;
using BLL.Services.PService;
using BLL.Services.Helpers;

namespace Shared.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<LogUserActivity>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
