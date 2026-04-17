using EFMDS.Web.Models;

namespace EFMDS.Web.Services.Interfaces;

public interface IGovernorateService
{
    Task<List<Governorate>> GetAllAsync();
    Task<Governorate?> GetByIdAsync(int id);
    Task<Governorate> AddAsync(Governorate governorate);
    Task<Governorate?> UpdateAsync(Governorate governorate);
    Task<bool> DeleteAsync(int id);
}