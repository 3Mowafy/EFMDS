using Microsoft.AspNetCore.Mvc;
using EFMDS.Web.Services.Interfaces;
using EFMDS.Web.Models;

namespace EFMDS.Web.Controllers;

[Route("districts")]
public class DistrictsController : Controller
{
    private readonly IDistrictService _districtService;
    private readonly IGovernorateService _governorateService;

    public DistrictsController(IDistrictService districtService,
    IGovernorateService governorateService)
    {
        _districtService = districtService;
        _governorateService = governorateService;
    }

    private async Task LoadGovernoratesAsync()
    {
        ViewBag.Governorates = await _governorateService.GetAllAsync();
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var districts = await _districtService.GetAllAsync();
        await LoadGovernoratesAsync();
        return View(districts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var district = await _districtService.GetByIdAsync(id);
        if (district == null)
            return NotFound();
        await LoadGovernoratesAsync();
        return View(district);
    }

    [HttpGet("create")]
    public async Task<IActionResult> Create()
    {
        ViewBag.Governorates = await _governorateService.GetAllAsync();
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(District district)
    {
        if (ModelState.IsValid)
        {
            await _districtService.AddAsync(district);
            return RedirectToAction(nameof(Index));
        }
        await LoadGovernoratesAsync();
        return View(district);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var district = await _districtService.GetByIdAsync(id);
        if (district == null)
            return NotFound();
        ViewBag.Governorates = await _governorateService.GetAllAsync();
        return View(district);
    }

    [HttpPost("edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, District district)
    {
        if (id != district.Id) return NotFound();

        if (ModelState.IsValid)
        {
            await _districtService.UpdateAsync(district);
            return RedirectToAction(nameof(Index));
        }
        await LoadGovernoratesAsync();
        return View(district);
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var district = await _districtService.GetByIdAsync(id);
        if (district == null)
            return NotFound();
        await LoadGovernoratesAsync();
        return View(district);
    }

    [HttpPost("delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _districtService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

}