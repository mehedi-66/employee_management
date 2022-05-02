
using EmployeManagement.Data;
using EmployeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeManagement.Controllers;
public class CategoryController : Controller
{
    // get the data from the database 
    private readonly ApplicationDbContext _db;
   
   public CategoryController(ApplicationDbContext db)
   {
       _db = db;
   }
   
    public IActionResult Index()
    {
       // var objCategory = _db.Categories.ToList();
       IEnumerable<Category> objCategory = _db.Categories;
       
        return View(objCategory);
    }
}