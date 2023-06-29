using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_API.Models;

namespace Web_API
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany(e => e.Cart_Items).WithOne(d => d.user).HasForeignKey(d => d.AssignedTo);
            //// modelBuilder.Entity<Employee>().HasMany(e => e.Devices).WithMany(d => d.Assignments).HasForeignKey(d => d);

            //modelBuilder.Entity<Employee>().HasMany(e => e.Assignments).WithOne(d => d.employee).HasForeignKey(d => d.EmployeeId);
            //modelBuilder.Entity<Device>().HasMany(e => e.Assignments).WithOne(d => d.device).HasForeignKey(d => d.DeviceId);

        }
    }
}