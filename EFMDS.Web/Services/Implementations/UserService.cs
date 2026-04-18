using EFMDS.Web.Models;
using EFMDS.Web.ViewModels;
using EFMDS.Web.Repositories.Interfaces;
using EFMDS.Web.Services.Interfaces;

namespace EFMDS.Web.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> LoginAsync(LoginViewModel model)
    {
        var user = await _userRepository.GetByEmailAsync(model.Email);

        if (user == null || !user.IsActive)
            return null;

        if (!PasswordHasher.Verify(model.Password, user.PasswordHash))
            return null;

        return user;
    }

    public async Task<User?> RegisterAsync(RegisterViewModel model)
    {
        var existing = await _userRepository.GetByEmailAsync(model.Email);
        if (existing != null)
            return null;

        var user = new User
        {
            FullName = model.FullName,
            Email = model.Email,
            PasswordHash = PasswordHasher.Hash(model.Password),
            Phone = model.Phone,
            RoleId = 4,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        return await _userRepository.AddAsync(user);
    }

    public Task<User?> GetByIdAsync(int id)
        => _userRepository.GetByIdAsync(id);

    public Task<List<User>> GetAllAsync()
        => _userRepository.GetAllAsync();

    public Task<User?> UpdateAsync(User user)
        => _userRepository.UpdateAsync(user);

    public Task<bool> DeactivateAsync(int id)
        => _userRepository.DeactivateAsync(id);
}