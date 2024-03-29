using System.ComponentModel.DataAnnotations;

namespace EmployeManagement.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public int DispalyOrder { get; set; }

    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}