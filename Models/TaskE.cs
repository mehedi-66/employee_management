using System.ComponentModel.DataAnnotations;

namespace EmployeManagement.Models;

public class TaskE
{
  [Key]
   public int Id { get; set; }
   
   [Required]
   public string Name { get; set;}

   [Required]
   public string Phone { get; set; }

    [Required]
   public string Date { get; set; }

    [Required]
   public string Status { get; set; }

    [Required]
   public string Details { get; set; }

 
}