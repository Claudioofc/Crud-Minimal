using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Person.Routes
{
    public static class AuthRoute
    {
        public static void AuthRoutes(this WebApplication app)
        {
            // Rota de Login que gera o Token
            app.MapPost("/login", (LoginRequest req, IConfiguration config) =>
            {
                if (req.Username == "admin" && req.Password == "123456")
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: config["Jwt:Issuer"],
                        audience: config["Jwt:Audience"],
                        claims: new[] { new Claim(ClaimTypes.Name, req.Username) },
                        expires: DateTime.UtcNow.AddHours(2),
                        signingCredentials: creds
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return Results.Ok(new { Token = tokenString });
                }

                return Results.Unauthorized();
            });
        }
    }

    public record LoginRequest(string Username, string Password);
}