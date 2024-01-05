using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;
using BOL;
using DAL;

namespace MVCApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

      [HttpGet]
    public IActionResult Display()
    {
        List<Timesheet> ls = DBManager.Display();
        this.ViewData["display"]=ls;
        return View();
    }

    [HttpGet]
    public IActionResult Insert()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Insert(string Date, string Work, int Duration, string Status)
    {
        Timesheet ts = new Timesheet(Date,Work,Duration,Status);
        DBManager.Insert(ts);
        return View();
    }
    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Update(int id, string Date, string Work, int Duration, string Status)
    {
        Timesheet ts = new Timesheet(id, Date,Work,Duration,Status);
        DBManager.Insert(ts);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
