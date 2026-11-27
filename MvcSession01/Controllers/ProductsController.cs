using Microsoft.AspNetCore.Mvc;
using MvcSession01.Models;

namespace MvcSession01.Controllers;

public class ProductsController : Controller
{
    private readonly ProductStore _store;

    public ProductsController(ProductStore store)
    {
        _store = store;
    }

    public IActionResult Index()
    {
        var products = _store.GetAll();
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = _store.GetById(id);
        if (product is null)
            return NotFound();     

        return View(product);     
    }

    [NonAction]                    
    public void Helper() { }
}