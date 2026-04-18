using EFMDS.Web.Models;

namespace EFMDS.Web.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(int id);
    Task<User> AddAsync(User user);
    Task<User?> UpdateAsync(User user);
    Task<List<User>> GetAllAsync();
    Task<bool> DeactivateAsync(int id);
}