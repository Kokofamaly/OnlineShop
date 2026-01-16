// using Microsoft.AspNetCore.Identity;
// using OnlineShop.Models;
// using OnlineShop.Data;

// namespace OnlineShop.Infrastructure;

// public static class IdentityConfig
// {
//     public static IServiceCollection AddIdentityInfrastructure(
//         this IServiceCollection services)
//     {
//         services
//             .AddIdentityCore<User>(options =>
//             {
//                 options.Password.RequiredLength = 5;
//             })
//             .AddRoles<IdentityRole<Guid>>()
//             .AddEntityFrameworkStores<ApplicationDbContext>()
//             .AddDefaultTokenProviders();

//         return services;
//     }
// }

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
            .AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}

