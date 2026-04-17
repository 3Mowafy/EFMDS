using Microsoft.AspNetCore.Mvc;
using EFMDS.Web.Services.Interfaces;
using EFMDS.Web.Models;

namespace EFMDS.Web.Controllers;

[Route("governorates")]
public class GovernoratesController : Controller
{
    private readonly IGovernorateService _governorateService;

    public GovernoratesController(IGovernorateService governorateService)
    {
        _governorateService = governorateService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var governorates = await _governorateService.GetAllAsync();
        return View(governorates);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var governorate = await _governorateService.GetByIdAsync(id);
        if (governorate == null)
            return NotFound();
        return View(governorate);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Governorate governorate)
    {
        if (ModelState.IsValid)
        {
            await _governorateService.AddAsync(governorate);
            return RedirectToAction(nameof(Index));
        }
        return View(governorate);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var governorate = await _governorateService.GetByIdAsync(id);
        if (governorate == null)
            return NotFound();
        return View(governorate);
    }

    [HttpPost("edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Governorate governorate)
    {
        if (id != governorate.Id) return NotFound();

        if (ModelState.IsValid)
        {
            await _governorateService.UpdateAsync(governorate);
            return RedirectToAction(nameof(Index));
        }
        return View(governorate);
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var governorate = await _governorateService.GetByIdAsync(id);
        if (governorate == null)
            return NotFound();
        return View(governorate);
    }

    [HttpPost("delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _governorateService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

}