
using EmployeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeManagement.Data;
public class ApplicationDbContext : DbContext
{
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base( options)
     {
         
     }

     public DbSet<Category> Categories { get; set; }
     public DbSet<Employe> employees { get; set; }

     public DbSet<TaskE> task { get; set; }
      public DbSet<Application> applications { get; set; }
}
