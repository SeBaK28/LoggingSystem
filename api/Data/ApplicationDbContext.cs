using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> cartProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole{
                    Name ="Admin",
                    NormalizedName = "ADMIN"
                },

                new IdentityRole{
                    Name ="User",
                    NormalizedName = "User"
                },

                new IdentityRole{
                    Name ="Moderator",
                    NormalizedName = "MODERATOR"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<User>()
            .HasOne(e => e.userCart)
            .WithOne(e => e.user)
            .HasForeignKey<Cart>(e => e.UserId)
            .IsRequired(false);

            builder.Entity<Cart>()
            .HasMany(e => e.ProductsList)
            .WithOne(e => e.cart)
            .HasForeignKey(e => e.UserCartId)
            .IsRequired(true);
        }
    }
}