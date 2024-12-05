using System.ComponentModel.DataAnnotations;
using Passport2.Models;

public class ResidencyApplication
{
    [Key]
    public int ResidencyApplicationID { get; set; }

    [Required]
    public string? FullName { get; set; }
    public string? Status { get; set; }

 
    public string? Email { get; set; }
    public DateTime DateOfApplication { get; set; }
 
    public string? PassportNumber { get; set; }
    public UserDetails UserDetails { get; set; } = new UserDetails();
}
