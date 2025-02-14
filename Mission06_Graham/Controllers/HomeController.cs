using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Graham.Models;
using SQLitePCL;

namespace Mission06_Graham.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;
    
    public HomeController(MovieContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Joel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult MovieForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MovieForm(Movie response)
    {
        _context.Movies.Add(response); //Adds the record to the database
        _context.SaveChanges();
        return View("Confirmation", response);
    }
}