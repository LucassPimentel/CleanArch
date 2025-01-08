using CleanArch.Application.Interfaces;
using CleanArch.Application.Mappings;
using CleanArch.Application.Services;
using CleanArch.Domain.Account;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Identity;
using CleanArch.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<AppDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            service.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            service.ConfigureApplicationCookie(opts => opts.AccessDeniedPath = "/Account/Login");

            service.AddScoped<IAuthenticate, AuthenticateService>();
            service.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IProductService, ProductService>();

            service.AddAutoMapper(typeof(DomainToDTOProfile));

            var handlersAssembly = AppDomain.CurrentDomain.Load("CleanArch.Application");
            service.AddMediatR(config => config.RegisterServicesFromAssembly(handlersAssembly));

            return service;
        }
    }
}
