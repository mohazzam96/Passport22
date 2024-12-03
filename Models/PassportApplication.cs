using System.ComponentModel.DataAnnotations;
namespace Passport2.Models
{
    public class PassportApplication
    {
        [Key]
        public int ApplicationID { get; set; }
        public int UserDetailsId { get; set; }
        public string? Status { get; set; }
        public string? PassportNumber { get; set; }
        public DateTime DateOfApplication { get; set; }


        public UserDetails UserDetails { get; set; } = new UserDetails();
    }
}