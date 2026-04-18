using EFMDS.Web.Models;

namespace EFMDS.Web.Repositories.Interfaces;

public interface IDistrictRepository
{
    Task<List<District>> GetAllAsync();
    Task<List<District>> GetByGovernorateAsync(int governorateId);
    Task<District?> GetByIdAsync(int id);
    Task<District> AddAsync(District district);
    Task<District?> UpdateAsync(District district);
    Task<bool> DeleteAsync(int id);
}