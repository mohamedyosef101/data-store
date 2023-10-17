using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using data_store.Models;

namespace data_store.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        using var db = new DataStoreContext();
        var brands = db.Brands.ToList();
        var services = db.Services.ToList();
        var testimonials = db.Testimonials.ToList();

        return View(Tuple.Create(brands, services, testimonials));
    }

    public ActionResult Projects()
    {
        using var db = new DataStoreContext();
        var projects = db.Projects.ToList();
        return View(projects);
    }

    public ActionResult Pricing()
    {
        return View();
    }

    public ActionResult About()
    {
        using var db = new DataStoreContext();
        var brands = db.Brands.ToList();
        return View(brands);
    }

    public IActionResult Details(int id)
    {
        try
        {
            using var db = new DataStoreContext();
            var ProjectWithCategory = db.Projects.Where(p => p.Id == id)
            .Join(
                db.Categories,
                project => project.CategoryId,
                category => category.Id,
                (project, category) => new ProjectWithCategory
                {
                    Project = project,
                    CategoryName = category.Name
                })
            .FirstOrDefault();

            if (ProjectWithCategory == null)
            {
                return NotFound(); // Handle if project with the given ID doesn't exist
            }
            return View(ProjectWithCategory);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "An error occurred while processing the Details action.");
            // Return an error view or message
            return View("Error");
        }
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
