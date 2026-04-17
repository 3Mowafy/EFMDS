using Microsoft.AspNetCore.Mvc;
using EFMDS.Web.Services.Interfaces;
using EFMDS.Web.Models;

namespace EFMDS.Web.Controllers;

[Route("specialties")]
public class SpecialtiesController : Controller
{
    private readonly ISpecialtyService _specialtyService;

    public SpecialtiesController(ISpecialtyService specialtyService)
    {
        _specialtyService = specialtyService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var specialties = await _specialtyService.GetAllAsync();
        return View(specialties);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var specialty = await _specialtyService.GetByIdAsync(id);
        if (specialty == null)
            return NotFound();
        return View(specialty);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Specialty specialty)
    {
        if (ModelState.IsValid)
        {
            await _specialtyService.AddAsync(specialty);
            return RedirectToAction(nameof(Index));
        }
        return View(specialty);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var specialty = await _specialtyService.GetByIdAsync(id);
        if (specialty == null)
            return NotFound();
        return View(specialty);
    }

    [HttpPost("edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Specialty specialty)
    {
        if (id != specialty.Id) return NotFound();

        if (ModelState.IsValid)
        {
            await _specialtyService.UpdateAsync(specialty);
            return RedirectToAction(nameof(Index));
        }
        return View(specialty);
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var specialty = await _specialtyService.GetByIdAsync(id);
        if (specialty == null)
            return NotFound();
        return View(specialty);
    }

    [HttpPost("delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _specialtyService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

}