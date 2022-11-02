using Microsoft.AspNetCore.Identity;

namespace WebApplication3.Data.Models
{
    public class School :IdentityUser
    {
        public string SchoolName { get; set; } = "";

        public int PerformanceRate { get; set; }

    }
}
