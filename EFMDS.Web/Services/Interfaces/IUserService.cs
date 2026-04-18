using EFMDS.Web.Models;
using EFMDS.Web.ViewModels;

namespace EFMDS.Web.Services.Interfaces;

public interface IUserService
{
    Task<User?> LoginAsync(LoginViewModel model);
    Task<User?> RegisterAsync(RegisterViewModel model);
    Task<User?> GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
    Task<User?> UpdateAsync(User user);
    Task<bool> DeactivateAsync(int id);
}