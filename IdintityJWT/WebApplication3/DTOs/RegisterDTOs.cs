using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTOs
{
    public class RegisterDTOs
    {
        [Required]
        public string Username { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";

        public string SchoolName { get; set; } = "";
        
    }
}
