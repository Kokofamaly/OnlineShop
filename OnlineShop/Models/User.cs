using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Infrastructure;

namespace OnlineShop.Models;

public class User : IdentityUser<Guid>
{
    public User() {}

    public User(string username, string email)
    {
        Id = Guid.NewGuid();
        UserName = username;
        Email = email;
    }
}