using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Models;

public class User
{
    public Guid Id { get; private set; }
    [Required]
    [MinLength(3)]
    public string? Username { get; private set; }
    [Required]
    public string? Email { get; private set; }
    public string? PasswordHash { get; private set; }
    public string? Role { get; private set; }

    public User() {}

    public User(string username, string email, string passwordHash, string role)
    {
        Id = Guid.NewGuid();
        Username = username;
        PasswordHash = passwordHash;
        Role = role;
    }
}