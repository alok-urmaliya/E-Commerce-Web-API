using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_API.Models;

namespace Web_API
{
    public class AppDbContext : IdentityDbContext<Customer>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Cart_Item> Cart_Items { get; set; }
        public DbSet<Wishlist_Item> Wishlist_Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Defining Customer connection to cart and wishlist.
            modelBuilder.Entity<Customer>().HasMany(e => e.cart_items).WithOne(d => d.customer).HasForeignKey(d=>d.customer_id);
            modelBuilder.Entity<Customer>().HasMany(e => e.wishlist_items).WithOne(d => d.customer).HasForeignKey(d => d.customer_id);

            //Defining 
            modelBuilder.Entity<Products>().HasMany(e => e.cart_items).WithOne(d => d.product).HasForeignKey(d => d.product_id);
            modelBuilder.Entity<Products>().HasMany(e => e.wishlist_items).WithOne(d => d.product).HasForeignKey(d => d.product_id);

        }
    }
}