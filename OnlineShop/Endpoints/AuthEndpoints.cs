using OnlineShop.Models;
using OnlineShop.Models.DTOs;
using OnlineShop.Services;

namespace OnlineShop.Endpoints;
public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/register", RegisterUser);
        app.MapPost("/login", LoginUser);
    }

    private static async Task<IResult> RegisterUser(AuthService service, string username, string email, string password)
    {
        User? user = await service.RegisterAsync(username, email, password);
        if(user == null) return Results.BadRequest("Error while registrating user");

        UserDTO userDTO = new UserDTO(user.UserName!, user.Email!, user.Id);
        return Results.Json(userDTO);
    }

    private static async Task<IResult> LoginUser(
        AuthService service,
        string email,
        string password)
    {
        var token = await service.LoginAsync(email, password);
        if (token == null)
            return Results.Unauthorized();

        return Results.Ok(new
        {
            accessToken = token
        });
    }

}