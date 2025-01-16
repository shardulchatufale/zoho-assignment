using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZwalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var ReaderRoleId = "3b00fc2e-0646-4c55-8ad8-edad1b62a462";
            var WriterRoleId = "6f730a17-0f40-4541-a5a4-4d9b2c002b27";

            // Define roles
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = ReaderRoleId,
                    ConcurrencyStamp = ReaderRoleId,
                    Name = "Reader",
                    NormalizedName = "READER".ToUpper()
                },
                new IdentityRole
                {
                    Id = WriterRoleId,
                    ConcurrencyStamp = WriterRoleId,
                    Name = "Writer",
                    NormalizedName = "WRITER".ToUpper()
                }
            };

            // Seed roles
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
