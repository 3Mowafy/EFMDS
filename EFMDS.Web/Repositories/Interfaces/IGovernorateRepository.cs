using EFMDS.Web.Models;

namespace EFMDS.Web.Repositories.Interfaces;

public interface IGovernorateRepository
{
    Task<List<Governorate>> GetAllAsync();
    Task<Governorate?> GetByIdAsync(int id);
    Task<Governorate> AddAsync(Governorate governorate);
    Task<Governorate?> UpdateAsync(Governorate governorate);
    Task<bool> DeleteAsync(int id);
}