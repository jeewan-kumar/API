// using MyApiProject.Models;
using System.Threading.Tasks;

public interface IAuthService
{
    Task<string> LoginAsync(LoginRequest loginRequest);
    Task<bool> SignupAsync(SignupRequest signupRequest);
}
