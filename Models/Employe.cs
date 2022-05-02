using System.ComponentModel.DataAnnotations;

namespace EmployeManagement.Models;

public class Employe
{
   [Key]
   public int Id { get; set; }
   
   [Required]
   public string Name { get; set;}

    [Required]
   public double Salary { get; set; }

   [Required]
   public string Phone { get; set; }

   [Required]
   public string Email { get; set; }

   [Required]
   public string Password { get; set; }

}