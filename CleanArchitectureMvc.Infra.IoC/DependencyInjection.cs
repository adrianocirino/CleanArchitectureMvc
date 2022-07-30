using System;
using CleanArchitectureMvc.Application.Interfaces;
using CleanArchitectureMvc.Application.Mappings;
using CleanArchitectureMvc.Application.Services;
using CleanArchitectureMvc.Domain.Account;
using CleanArchitectureMvc.Domain.Interfaces;
using CleanArchitectureMvc.Infra.Data.Context;
using CleanArchitectureMvc.Infra.Data.Identity;
using CleanArchitectureMvc.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                    , b => b.MigrationsAssembly((typeof(ApplicationDbContext).Assembly.FullName)));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/Login";
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddAutoMapper(typeof(DtoToCommandMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("CleanArchitectureMvc.Application");
            services.AddMediatR(myHandlers);


            return services;
        }
    }
}
