using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeManagement.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmployeManagement.Controllers;

public class HomeController : Controller
{
    // for database connection 
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
        return View();
    }
     public IActionResult formAdmin()
    {
        
        return View();
    }

     public IActionResult formWorker()
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
