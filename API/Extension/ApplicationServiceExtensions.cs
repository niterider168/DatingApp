using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using API.Interface;
using API.Services;
using API.Data;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using API.Interfaces;
using AutoMapper;
using API.Helpers;

namespace API.Extension
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

             services.AddScoped<ITokenService, TokenService>();
             services.AddScoped<IUserRepository, UserRepository>();
             services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {

                options.UseSqlite(config.GetConnectionString("DefaultConnection"));


            });
            return services;
        }
    }
}