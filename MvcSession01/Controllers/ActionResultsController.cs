using Microsoft.AspNetCore.Mvc;

namespace MvcSession01.Controllers;

public class ActionResultsController : Controller
{
    public IActionResult Index()
    {
        return Content("You reached the Index action.");
    }

    public IActionResult Text()
    {
        return Content("Hello! This is plain text (ContentResult).");
    }

    public JsonResult GetProduct()
        => Json(new { Id = 1, Name = "Laptop" });
    public IActionResult Product(int id)
    {
        if (id > 100) return NotFound();                  
        if (id == 42) return RedirectToAction("Index");   
        return Json(new { Id = id });
    }

    public IActionResult Go()
    {
        return RedirectToAction("Index", "Products");
    }

    public IActionResult External()
    {
        return Redirect("https://learn.microsoft.com");
    }

    public IActionResult Success()
    {
        return Ok("This is a 200 OK.");
    }

    public IActionResult Bad()
    {
        return BadRequest("This is a 400 Bad Request.");
    }

    public IActionResult Teapot()
    {
        return StatusCode(418);
    }

    public IActionResult Download()
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes("Hello from a downloaded file.");
        return File(bytes, "text/plain", "hello.txt");
    }

    public IActionResult Partial()
    {
        return PartialView("_Greeting");
    }
}