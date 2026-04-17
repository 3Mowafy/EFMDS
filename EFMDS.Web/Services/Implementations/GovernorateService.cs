using EFMDS.Web.Services.Interfaces;
using EFMDS.Web.Repositories.Interfaces;
using EFMDS.Web.Models;

namespace EFMDS.Web.Services.Implementations;

public class GovernorateService : IGovernorateService
{
    private readonly IGovernorateRepository _governorateRepository;

    public GovernorateService(IGovernorateRepository governorateRepository)
    {
        _governorateRepository = governorateRepository;
    }

    public async Task<List<Governorate>> GetAllAsync()
    {
        return await _governorateRepository.GetAllAsync();
    }

    public async Task<Governorate?> GetByIdAsync(int id)
    {
        return await _governorateRepository.GetByIdAsync(id);
    }

    public async Task<Governorate> AddAsync(Governorate governorate)
    {
        return await _governorateRepository.AddAsync(governorate);
    }

    public async Task<Governorate?> UpdateAsync(Governorate governorate)
    {
        return await _governorateRepository.UpdateAsync(governorate);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _governorateRepository.DeleteAsync(id);
    }
}