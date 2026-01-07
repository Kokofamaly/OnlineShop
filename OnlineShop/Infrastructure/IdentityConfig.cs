using Microsoft.AspNetCore.Identity;
using OnlineShop.Models;
using OnlineShop.Data;

namespace OnlineShop.Infrastructure;

public static class IdentityConfig
{
    public static IServiceCollection AddIdentityInfrastructure(
        this IServiceCollection services)
    {
        services
            .AddIdentityCore<User>(options =>
            {
                options.Password.RequiredLength = 5;
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}
