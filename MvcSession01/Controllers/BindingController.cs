using Microsoft.AspNetCore.Mvc;
using MvcSession01.Models;

namespace MvcSession01.Controllers;

public class BindingController : Controller
{
    public IActionResult Details(int id, string sort)
    {
        return Content($"id = {id} , sort = {sort}");
    }
    public IActionResult Sources([FromRoute] int id, [FromQuery] int page,
        [FromHeader(Name = "User-Agent")] string userAgent)
    {
        return Content($"id = {id} , page = {page} , browser = {userAgent}");
    }
    public IActionResult Create(Student student)
    {
        return Content($"Name = {student.Name} , Age = {student.Age} , valid = {ModelState.IsValid}");
    }
}