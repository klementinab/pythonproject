using FruitsTraceabilitySystem.Domain.Models.Categories;
using FruitsTraceabilitySystem.Domain.Models.Harvests;
using FruitsTraceabilitySystem.Domain.Models.Packages;
using FruitsTraceabilitySystem.Domain.Models.Packangins;
using FruitsTraceabilitySystem.Domain.Models.Products;
using FruitsTraceabilitySystem.Domain.Models.Sortings;
using FruitsTraceabilitySystem.Domain.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FruitsTraceabilitySystem.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        #region Properties
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Harvest> Harvests { get; set; }
        public DbSet<Sorting> Sortings { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Packanging> Packangings { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        #endregion

        #region Constructors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        #endregion

        #region ProtectedMethod
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();

            builder.Entity<Harvest>()
               .HasOne(x => x.Product)
               .WithMany(x => x.Harvests)
               .HasForeignKey(x => x.ProductId)
               .IsRequired();

            builder.Entity<Harvest>()
              .HasOne(x => x.User)
              .WithMany(x => x.Harvests)
              .HasForeignKey(x => x.UserId)
              .IsRequired();

            builder.Entity<Sorting>()
               .HasOne(x => x.Harvest)
               .WithMany(x => x.Sortings)
               .HasForeignKey(x => x.HarvestId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            builder.Entity<Sorting>()
              .HasOne(x => x.User)
              .WithMany(x => x.Sortings)
              .HasForeignKey(x => x.UserId)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired();

            builder.Entity<Packanging>()
               .HasOne(x => x.Package)
               .WithMany(x => x.Packangings)
               .HasForeignKey(x => x.PackageId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            builder.Entity<Packanging>()
               .HasOne(x => x.ProductSorting)
               .WithMany(x => x.Packangings)
               .HasForeignKey(x => x.ProductSortingId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            builder.Entity<Packanging>()
              .HasOne(x => x.User)
              .WithMany(x => x.Packangings)
              .HasForeignKey(x => x.UserId)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired();
        }
        #endregion
    }
}
