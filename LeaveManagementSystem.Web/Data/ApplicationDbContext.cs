using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "d5064038-32d2-4545-a5f2-a33c62df1803",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole 
                {
                    Id = "d5cc9a1d-dabe-4a85-ba55-b19f73ced1db",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR"
                },
                new IdentityRole 
                {
                    Id = "0257c513-3596-404b-b8f6-368caa8efba1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                    Id = "3159fda0-b934-4a57-bc07-d0a3615cf231",
                    Email = "admin@gmail.test",
                    NormalizedEmail = "ADMIN@GMAIL.TEST",
                    NormalizedUserName = "ADMIN@GMAIL.TEST",
                    UserName = "admin@gmail.test",
                    PasswordHash = hasher.HashPassword(null, "Mualnauli4."),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1992,12,01)

                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string> 
                    {
                        RoleId = "0257c513-3596-404b-b8f6-368caa8efba1",
                        UserId = "3159fda0-b934-4a57-bc07-d0a3615cf231"
                    });
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
    }
    
