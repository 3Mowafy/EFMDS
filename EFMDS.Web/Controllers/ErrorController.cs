using Microsoft.AspNetCore.Mvc;

public class ErrorController : Controller
{
    public IActionResult NotFoundPage()
    {
        return View();
    }
}