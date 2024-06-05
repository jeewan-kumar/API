// using MyApiProject.Models;
using System.Threading.Tasks;

public interface IUserService
{
    Task<bool> UpdateUserAsync(UpdateUserRequest updateUserRequest);
    Task<UserResponse> GetUserAsync(string username);
}
