using EFMDS.Web.Services.Interfaces;
using EFMDS.Web.Repositories.Interfaces;
using EFMDS.Web.Models;

namespace EFMDS.Web.Services.Implementations;

public class SpecialtyService : ISpecialtyService
{
    private readonly ISpecialtyRepository _specialtyRepository;

    public SpecialtyService(ISpecialtyRepository specialtyRepository)
    {
        _specialtyRepository = specialtyRepository;
    }

    public async Task<List<Specialty>> GetAllAsync()
    {
        return await _specialtyRepository.GetAllAsync();
    }

    public async Task<Specialty?> GetByIdAsync(int id)
    {
        return await _specialtyRepository.GetByIdAsync(id);
    }

    public async Task<Specialty> AddAsync(Specialty specialty)
    {
        return await _specialtyRepository.AddAsync(specialty);
    }

    public async Task<Specialty?> UpdateAsync(Specialty specialty)
    {
        return await _specialtyRepository.UpdateAsync(specialty);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _specialtyRepository.DeleteAsync(id);
    }
}