using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TSDOblig1.Models;
using TSDOblig1.Data; 
using System.Linq;    // For .OrderByDescending()

namespace TSDOblig1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BrukerContext _context; // ✅ BrukerContext for database

    public HomeController(ILogger<HomeController> logger, BrukerContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Spill()
    {
        var topPlayers = _context.Brukere
            .OrderByDescending(b => b.AntallSpill)
            .ToList();

        ViewBag.TopPlayers = topPlayers;

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpGet]
    
    public IActionResult HentRangering()
    {
        var topPlayers = _context.Brukere
            .OrderByDescending(b => b.AntallSpill)
            .Select((b, i) => new {
                Nummer = i + 1,
                Navn = b.Navn,
                AntallSpill = b.AntallSpill
            })
            .ToList();

        return Json(topPlayers);
    }


}
