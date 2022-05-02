using System.ComponentModel.DataAnnotations;

namespace EmployeManagement.Models;

public class login
{

    [Required]
   public int Id { get; set; }

    [Required]
   public string Password { get; set; }
 
}