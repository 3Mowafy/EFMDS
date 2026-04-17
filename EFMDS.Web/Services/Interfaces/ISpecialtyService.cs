using EFMDS.Web.Models;

namespace EFMDS.Web.Services.Interfaces;

public interface ISpecialtyService
{
    Task<List<Specialty>> GetAllAsync();
    Task<Specialty?> GetByIdAsync(int id);
    Task<Specialty> AddAsync(Specialty specialty);
    Task<Specialty?> UpdateAsync(Specialty specialty);
    Task<bool> DeleteAsync(int id);
}