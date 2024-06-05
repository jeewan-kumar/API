// using MyApiProject.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<string> LoginAsync(LoginRequest loginRequest)
    {
        // Validate credentials (this is just a placeholder, you should validate against your database)
        if (loginRequest.Username == "test" && loginRequest.Password == "password")
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["jwt_config:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("username", loginRequest.Username) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(tokenHandler.WriteToken(token));
        }
        return Task.FromResult<string>(null);
    }

    public Task<bool> SignupAsync(SignupRequest signupRequest)
    {
        // Implement user signup logic (save user to the database)
        // This is just a placeholder, always return true for successful signup
        return Task.FromResult(true);
    }
}
