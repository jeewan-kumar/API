using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// using MyApiProject.Models;
// using MyApiProject.Services;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var result = await _authService.LoginAsync(loginRequest);
        if (result == null)
        {
            return Unauthorized("Invalid credentials");
        }
        return Ok(result);
    }

    [HttpPost("signup")]
    [AllowAnonymous]
    public async Task<IActionResult> Signup(SignupRequest signupRequest)
    {
        var result = await _authService.SignupAsync(signupRequest);
        if (!result)
        {
            return BadRequest("Signup failed");
        }
        return Ok("Signup successful");
    }
}
