using Ispit19072022.Models.Dbo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ispit19072022.Data
{
    public class ApplicationDbContext : IdentityDbContext<AspNetUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string role = "admin";
            string userName = "admin@admin.com";
            string roleId = "d6b5b0da-e61e-46ba-b766-e1acc7401352";
            string userId = "badd4ddd-df0e-4621-af37-c2b36aaa6742";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = role,
                NormalizedName = "ADMIN",
                Id = roleId
            });
            var hasher = new PasswordHasher<AspNetUser>();
            builder.Entity<AspNetUser>().HasData(new AspNetUser
            {
                Id = userId,
                UserName = userName,
                Email = userName,
                NormalizedUserName = userName.ToUpper(),
                NormalizedEmail = userName.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password12345"),
                //SecurityStamp = Guid.NewGuid().ToString("D"),
                SecurityStamp = "c8c5cc23-1703-4984-8ac7-4b178d2d9982"

            });


            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });

        }



        public DbSet<AspNetUser> AspNetUser { get; set; }
        public DbSet<Models.Dbo.Task> Task { get; set; }
        public DbSet<ToDoList> ToDoList { get; set; }

    }
}