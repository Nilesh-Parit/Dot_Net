using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;
using DAL;
using BOL;

namespace MVCApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Insert()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Insert(int EmpID,string Fname,string Lname,string Gender,string Dept,int Salary)
    {
        Employee emp = new Employee(EmpID,Fname,Lname,Gender,Dept,Salary);
        DBManager.Insert(emp);
        return View();
    }

    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Update(int EmpID,string Fname,string Lname,string Gender,string Dept,int Salary)
    {
        Employee emp = new Employee(EmpID,Fname,Lname,Gender,Dept,Salary);
        DBManager.Update(emp);
        return View();
    }

    [HttpGet]
    public IActionResult Delete()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Delete(int EmpID)
    {
        DBManager.Delete(EmpID);
        return View();
    }

    [HttpGet]
    public IActionResult Display()
    {
        List<Employee> ls = DBManager.Display();
        this.ViewData["display"]=ls;
        return View();
    }

    public IActionResult Index()
    {
        return View();
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
