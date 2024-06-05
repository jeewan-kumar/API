using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// using MyApiProject.Models;
// using MyApiProject.Services;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPut("update")]
    [Authorize]
    public async Task<IActionResult> Update(UpdateUserRequest updateUserRequest)
    {
        var result = await _userService.UpdateUserAsync(updateUserRequest);
        if (!result)
        {
            return BadRequest("Update failed");
        }
        return Ok("Update successful");
    }

    [HttpGet("{username}")]
    [Authorize]
    public async Task<IActionResult> GetUser(string username)
    {
        var user = await _userService.GetUserAsync(username);
        if (user == null)
        {
            return NotFound("User not found");
        }
        return Ok(user);
    }
}
