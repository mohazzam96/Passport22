using Passport2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class UserDetails
{
    [Key]
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;  // Initialize with a default value
    public string Email { get; set; } = string.Empty;     // Initialize with a default value
    public string PhoneNumber { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PassportNumber {  get; set; } = string.Empty;

    public List<PassportApplication> PassportApplications { get; set; } = new List<PassportApplication>();
    public List<Residency> Residencies { get; set; } = new List<Residency>();
    public List<ResidencyApplication> ResidencyApplications { get; set;} = new List<ResidencyApplication>();
}


