using EmployeManagement.Data;
using EmployeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeManagement.Controllers;
public class WorkerController : Controller
{
    // get the data from the database 
    private readonly ApplicationDbContext _db;
    public WorkerController(ApplicationDbContext db)
    {
        _db = db;
    }
     public IActionResult index(int? id)
    {
        var employeesFromDb = _db.employees.Find(id);
        return View("~/Views/Worker/profile.cshtml", employeesFromDb);
    }
    [HttpPost]
    public IActionResult profile(login obj)
    {
        if (ModelState.IsValid)
        {
            if (obj.Id == null || obj.Id == 0)
            {
                return NotFound();
            }
            var employeesFromDb = _db.employees.Find(obj.Id);
            if (employeesFromDb == null)
            {   
                ViewData["ID"] = "ID is not found";
                return View("~/Views/Home/formWorker.cshtml");
            }
           if(employeesFromDb != null && obj.Password == employeesFromDb.Password){
                return View(employeesFromDb);
           }
           else{
                ViewData["Pass"] = "password not Match";
                return View("~/Views/Home/formWorker.cshtml");
           }
        }
        return View();
    }
    public IActionResult Application(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var employeesFromDb = _db.employees.Find(id);
        if (employeesFromDb == null)
        {
            return View();
        }
        ViewData["ID"] = id;
        ViewData["Name"] = employeesFromDb.Name;
        return View();
    }
    [HttpPost]
    public IActionResult Application(Application obj)
    {
        if (ModelState.IsValid)
        {
           _db.applications.Add(obj);
           _db.SaveChanges();
            var employeesFromDb = _db.employees.Find(obj.Id);
            return View("~/Views/Worker/profile.cshtml", employeesFromDb);
        }
        return View("~/Views/Worker/profile.cshtml");
    }
    public IActionResult Task(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var employeesFromDb = _db.task.Find(id);
        if (employeesFromDb == null)
        {
            ViewData["ID"] = id;
            return View("~/Views/Worker/taskNot.cshtml");
        }
        return View(employeesFromDb);
    }
    public IActionResult showDetails(int? id)
    {
         var employeesFromDb = _db.task.Find(id);
         return View(employeesFromDb);
    }
}

