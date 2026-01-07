namespace OnlineShop.Models.DTOs;

public class UserDTO
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public Guid Id { get; set; }

    public UserDTO(string username, string email, Guid id)
    {
        Username = username;
        Email = email;
        Id = id;
    }

}