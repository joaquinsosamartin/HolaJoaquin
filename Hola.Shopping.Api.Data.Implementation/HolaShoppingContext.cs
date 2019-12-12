using System.ComponentModel.DataAnnotations;
using System.Linq;
using Hola.Shopping.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Hola.Shopping.Api.Data.Implementation
{
    public class HolaShoppingContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Size> Sizes { get; set; }

        public HolaShoppingContext(DbContextOptions options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                where e.State == EntityState.Added
                      || e.State == EntityState.Modified
                select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().Property(a => a.Name).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(a => a.Name).IsRequired().HasMaxLength(300);
            modelBuilder.Entity<Customer>().Property(a => a.Email).IsRequired().HasMaxLength(300);
            modelBuilder.Entity<Customer>().Property(a => a.IdentificationNumber).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Customer>().Property(a => a.FullAddress).IsRequired().HasMaxLength(300);

            modelBuilder.Entity<Invoice>(builder =>
            {
                builder.Property(j => j.Date).IsRequired().HasColumnType("DATETIME2");
                builder.Property(j => j.GrossAmount).IsRequired().HasColumnType("decimal(18, 2)");
                builder.Property(j => j.Tax).IsRequired().HasColumnType("decimal(18, 2)");
                builder.Property(j => j.Total).IsRequired().HasColumnType("decimal(18, 2)");

            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.Property(j => j.Date).IsRequired().HasColumnType("DATETIME2");
                builder.Property(j => j.Amount).IsRequired().HasColumnType("decimal(18, 2)");
                builder.Property(j => j.Tax).IsRequired().HasColumnType("decimal(18, 2)");
                builder.Property(j => j.TotalAmount).IsRequired().HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Product>().Property(a => a.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Product>().Property(a => a.Color).HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(a => a.Description).IsRequired().HasColumnType("NVARCHAR(MAX)");
            modelBuilder.Entity<Product>().Property(a => a.Reference).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(a => a.Barcode128).HasColumnType("NVARCHAR(150)");
            modelBuilder.Entity<Product>().Property(j => j.Price).IsRequired().HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>().HasOne(p => p.Size).WithMany(s => s.Products);
            
            modelBuilder.Entity<Attachment>().Property(a => a.Name).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Attachment>().Property(a => a.FileUrl).IsRequired().HasMaxLength(500);

            modelBuilder.Entity<Shop>().Property(a => a.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Shop>().Property(a => a.FiscalCode).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Shop>().Property(a => a.Address1).HasMaxLength(300);
            modelBuilder.Entity<Shop>().Property(a => a.Address2).HasMaxLength(300);
            modelBuilder.Entity<Shop>().Property(a => a.Region).HasMaxLength(100);
            modelBuilder.Entity<Shop>().Property(a => a.ZipCode).HasMaxLength(8);
            modelBuilder.Entity<Shop>().Property(a => a.Country).HasMaxLength(100);
            modelBuilder.Entity<Shop>().Property(a => a.Sector).HasMaxLength(150);

            modelBuilder.Entity<Size>().Property(a => a.CountryIso).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Size>().Property(a => a.Value).HasMaxLength(20);

            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });
            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Order)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(po => po.OrderId);
        }
    }
}
