using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data.Models;

namespace WebApplication3.Data
{
    public class SchoolDBConterxt : IdentityDbContext<School>
    {
        public SchoolDBConterxt(DbContextOptions<SchoolDBConterxt> options) : base(options)
        {

        }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<School>().ToTable("SchoolUser");
        }
    }
}
