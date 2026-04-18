using EFMDS.Web.Models;

namespace EFMDS.Web.Services.Interfaces;

public interface IDistrictService
{
    Task<List<District>> GetAllAsync();
    Task<List<District>> GetByGovernorateAsync(int governorateId);
    Task<District?> GetByIdAsync(int id);
    Task<District> AddAsync(District district);
    Task<District?> UpdateAsync(District district);
    Task<bool> DeleteAsync(int id);
}