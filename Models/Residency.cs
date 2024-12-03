using Passport2.Models;
using System.ComponentModel.DataAnnotations;
public class Residency
{
    [Key]
    public int ResidencyID { get; set; }
    public string ForeignResidentName { get; set; } = string.Empty; // Initialize with default value
    public string Nationality { get; set; } = string.Empty;         // Initialize with default value
    public string Address { get; set; } = string.Empty;             // Initialize with default value

    public UserDetails UserDetails { get; set; } = new UserDetails();
}
