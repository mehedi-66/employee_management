using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeManagement.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using EmployeManagement.Data;

namespace EmployeManagement.Controllers;

public class AdminController : Controller
{
    // for database connection 
    private readonly ApplicationDbContext _db;
    public AdminController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult admin()
    {
        IEnumerable<Employe> objects = _db.employees;
        return View(objects);
    }

    [HttpPost]
    public IActionResult admin(login obj)
    {
        if (obj.Id == null || obj.Id == 0)
        {
            return NotFound();
        }
        if (obj.Id != 123)
        {
            ViewData["ID"] = "ID is not found";
            return View("~/Views/Home/formAdmin.cshtml");
        }
        if (obj.Id != null && obj.Password == "abc")
        {
            IEnumerable<Employe> objects = _db.employees;
            return View(objects);
        }
        else
        {
            ViewData["Pass"] = "password not Match";
            return View("~/Views/Home/formAdmin.cshtml");
        }
    }
    public IActionResult Employeditails()
    {
        return View();
    }
    // GET
    public IActionResult add()
    {
        return View();
    }
    // POST
    [HttpPost]
    public IActionResult add(Employe obj)
    {
        if (ModelState.IsValid)
        {
            _db.employees.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("admin");
        }
        return View(obj);
    }
    // GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var employeesFromDb = _db.employees.Find(id);
        if (employeesFromDb == null)
        {
            return NotFound();
        }
        return View(employeesFromDb);
    }
    // POST
    [HttpPost]
    public IActionResult Edit(Employe obj)
    {
        if (ModelState.IsValid)
        {
            _db.employees.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("admin");
        }
        return View(obj);
    }
    // GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var employeesFromDb = _db.employees.Find(id);
        if (employeesFromDb == null)
        {
            return NotFound();
        }
        return View(employeesFromDb);
    }
    // POST
    [HttpPost]
    public IActionResult DeletePost(int? Id)
    {
        var obj = _db.employees.Find(Id);
        if (obj == null)
        {
            return NotFound();
        }
        _db.employees.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("admin");
    }
    // *************** Task Page Work ******************* 
    public IActionResult task()
    {
        IEnumerable<TaskE> objects = _db.task;
        return View(objects);
    }
    // GET
    public IActionResult newTask(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var employeesFromDb = _db.employees.Find(id);
        if (employeesFromDb == null)
        {
            return NotFound();
        }
        ViewData["ID"] = id;
        ViewData["Name"] = employeesFromDb.Name;
        return View();
    }
    // POST
    [HttpPost]
    public IActionResult newTask(TaskE obj)
    {
        // find some elements from the emploeye table 
        if (ModelState.IsValid)
        {
            _db.task.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Task");
        }
        return View(obj);
    }
    // Get 
    public IActionResult TaskDetails(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var employeesFromDb = _db.task.Find(id);
        if (employeesFromDb == null)
        {
            return NotFound();
        }
        return View(employeesFromDb);
    }
    // Get 
    public IActionResult TaskDelete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var employeesFromDb = _db.task.Find(id);
        if (employeesFromDb == null)
        {
            return NotFound();
        }
        return View(employeesFromDb);
    }
    // POST
    [HttpPost]
    public IActionResult TaskDeletePost(int? Id)
    {
        if (Id == null || Id == 0)
        {
            return NotFound();
        }
        var obj = _db.task.Find(Id);
        if (obj == null)
        {
            return NotFound();
        }
        _db.task.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("task");
    }
    // **************** END Task Page done ***************

    // ************ START Query Page data *************
    public IActionResult query()
    {
        IEnumerable<Application> objects = _db.applications;
        return View(objects);
    }
    public IActionResult showMore(int? id)
    {
        var employeesFromDb = _db.applications.Find(id);
        if (employeesFromDb == null)
        {
            return NotFound();
        }
        return View(employeesFromDb);
    }
    public IActionResult approve(int? id)
    {
         var obj = _db.applications.Find(id);
        obj.Status = "Approved";
        _db.applications.Update(obj);
        _db.SaveChanges();

        IEnumerable<Application> objects = _db.applications;
        return View("~/Views/Admin/query.cshtml", objects);
    }
    public IActionResult pending(int? id)
    {
        var obj = _db.applications.Find(id);
        obj.Status = "Pending";
        _db.applications.Update(obj);
        _db.SaveChanges();

        IEnumerable<Application> objects = _db.applications;
        return View("~/Views/Admin/query.cshtml", objects);
    }
    public IActionResult reject(int? id)
    {
        var obj = _db.applications.Find(id);
        obj.Status = "Reject";
        _db.applications.Update(obj);
        _db.SaveChanges();

        IEnumerable<Application> objects = _db.applications;
        return View("~/Views/Admin/query.cshtml", objects);
    }
    public IActionResult deleteReq(int? id)
    {
        var obj = _db.applications.Find(id);
        
        _db.applications.Remove(obj);
        _db.SaveChanges();

        IEnumerable<Application> objects = _db.applications;
        return View("~/Views/Admin/query.cshtml", objects);
    }

    // *************** END Query Page **********************

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}