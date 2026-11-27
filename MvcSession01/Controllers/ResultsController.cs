using Microsoft.AspNetCore.Mvc;

namespace MvcSession01.Controllers;

[Route("results")]
public class ResultsController : Controller
{
    [HttpGet("json")]                
    public IActionResult Json()
    {
        return Json(new { Id = 1, Name = "Laptop" });
    }

    [HttpGet("status/{code:int}")]   
    public IActionResult Status(int code)
    {
        return StatusCode(code);
    }
    [HttpGet("product/{id:min(1)}")]          
    public IActionResult Product(int id)
    {
        return Content($"Product id = {id}");
    }

    [HttpGet("hello/{name:alpha}")]           
    public IActionResult Hello(string name)
    {
        return Content($"Hello {name}");
    }

    [HttpGet("user/{name:length(3,20)}")]    
    public IActionResult User(string name)
    {
        return Content($"User: {name}");
    }

    [HttpGet("date/{date:datetime}")]         // a valid date
    public IActionResult ByDate(DateTime date)
    {
        return Content($"Date: {date:yyyy-MM-dd}");
    }

    
}