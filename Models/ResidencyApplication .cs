using System.ComponentModel.DataAnnotations;
using Passport2.Models;

public class ResidencyApplication
{
    [Key]
    public int ResidencyApplicationID { get; set; }

    [Required]
    [StringLength(100)]
    public string? FullName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [StringLength(50)]
    public string? PassportNumber { get; set; }
}
