using EFMDS.Web.Services.Interfaces;
using EFMDS.Web.Repositories.Interfaces;
using EFMDS.Web.Models;

namespace EFMDS.Web.Services.Implementations;

public class DistrictService : IDistrictService
{
    private readonly IDistrictRepository _districtRepository;

    public DistrictService(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
    }

    public async Task<List<District>> GetAllAsync()
    {
        return await _districtRepository.GetAllAsync();
    }

    public async Task<List<District>> GetByGovernorateAsync(int governorateId)
    {
        return await _districtRepository.GetByGovernorateAsync(governorateId);
    }

    public async Task<District?> GetByIdAsync(int id)
    {
        return await _districtRepository.GetByIdAsync(id);
    }

    public async Task<District> AddAsync(District district)
    {
        return await _districtRepository.AddAsync(district);
    }

    public async Task<District?> UpdateAsync(District district)
    {
        return await _districtRepository.UpdateAsync(district);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _districtRepository.DeleteAsync(id);
    }
}