using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.CustomizeButtonRepo;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.SliderRepo;
using Replyment.Application.Abstraction.Services;
using Replyment.Application.Validators.SliderValidators;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;
using Replyment.Persistance.Implementations.Repositories.IEntityRepository.CustomizeButtonRepo;
using Replyment.Persistance.Implementations.Repositories.IEntityRepository.SliderRepo;
using Replyment.Persistance.Implementations.Services;
using Replyment.Persistance.MapperProfiles;
using System.Text;

namespace Replyment.Persistance.ExtensionsMethods;

public static class ServiceRegistration
{

    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(services.BuildServiceProvider().GetService<IConfiguration>().GetConnectionString("Default"));
        });


        //Repository
        services.AddReadRepositories();
        services.AddWriteRepositories();

        //Service
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ISliderServices,SliderServices>();
        services.AddScoped<ICustomizeButtonService, CustomizeButtonService>();


        //User
        services.AddIdentity<AppUser, IdentityRole>(Options =>
        {
            Options.User.RequireUniqueEmail = true;
            Options.Password.RequireNonAlphanumeric = true;
            Options.Password.RequiredLength = 8;
            Options.Password.RequireDigit = true;
            Options.Password.RequireUppercase = true;
            Options.Password.RequireLowercase = true;

            Options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            Options.Lockout.MaxFailedAccessAttempts = 3;
            Options.Lockout.AllowedForNewUsers = true;
        }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();


        //Mapper
        services.AddAutoMapper(typeof(SliderProfile).Assembly);


        //Validator
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<SliderGetDtoValidator>();

    }

    private static void AddReadRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISliderReadRepository, SliderReadRepository>();
        services.AddScoped<ICustomizeButtonReadRepository, CustomizeButtonReadRepository>();
    }

    private static void AddWriteRepositories(this IServiceCollection services) 
    {
        services.AddScoped<ISliderWriteRepository, SliderWriteRepository>();
        services.AddScoped<ICustomizeButtonWriteRepository, CustomizeButtonWriteRepository>();
    }

}
