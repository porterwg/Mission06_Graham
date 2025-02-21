using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Graham.Models;
using SQLitePCL;

namespace Mission06_Graham.Controllers;
//this is a very important page. I'll try to generally explain each action
//FYI!! I can't add comments to appsetting.json so I'll put them here -- I successfully changed the database to the one provided
public class HomeController : Controller
{
    private MovieContext _context;
    
    public HomeController(MovieContext context)
    {
        _context = context;
    }

    //this action just pulls up the home index page
    public IActionResult Index()
    {
        return View();
    }

    //this action pulls up the page about joel
    public IActionResult Joel()
    {
        return View();
    }

    //This action allows the user to submit a new movie to the database
    //It's made in such a way that categories are shown in a drop down instead of category Ids
    [HttpGet]
    public IActionResult MovieForm()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName).ToList();
        return View(new Movie());
    }

    //this action actually submits the new movie to the database and redirects to a confirmation page
    //If the necessary fields aren't filled, an error is shown and the user stays on the page
    [HttpPost]
    public IActionResult MovieForm(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); //Adds the record to the database
            _context.SaveChanges();
            return View("Confirmation", response);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View(response);
        }

    }

    //This pulls up all of the movies in a nice lice ordered by title (inlcuding category names instead of IDs)
    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title).ToList();
        return View(movies);
    }

    //Pulls up the movie form page but with the chosen movie already loaded up to be edited instead of added
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName).ToList();

        return View("MovieForm", recordToEdit);
    }

    //Commits changes to selected movie within the database and returns the user to the movies list
    [HttpPost]
    public IActionResult Edit(Movie response)
    {
        _context.Update(response);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }

    //Pulls ups a page to insure the user actually wants to delete the chosen record
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    //Actually deletes the selected record within the database and redirects back to the movie list
    [HttpPost]
    public IActionResult Delete(Movie response)
    {
        _context.Movies.Remove(response);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
}