using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_demo.DAL
{
    public class VendingMachineContext : DbContext, IVendingMachineContext
    {
        public string DbPath { get; }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }


        public VendingMachineContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "vendingmachine.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "Drinks"},
                new ProductType { Id = 2, Name = "Chips"},
                new ProductType { Id = 3, Name = "Candy" },
                new ProductType { Id = 4, Name = "Cookies" }
                );



            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Coca-Cola" },
                new Manufacturer { Id = 2, Name = "Pepsi" },
                new Manufacturer { Id = 3, Name = "Tollhouse" },
                new Manufacturer { Id = 4, Name = "Nabisco" }
                );



        }

    }

    public interface IVendingMachineContext
    {
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }
        DbSet<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(Manufacturer))]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        [ForeignKey(nameof(ProductType))]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductVM
    {
        [Required]
        [MinLength(5)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Manufacturer")]
        public int ManufacturerId { get; set; }

        [Required]
        [DisplayName("Product Type")]
        public int ProductTypeId { get; set; }

        [DisplayName("Price")]
        [Required]
        public decimal Price { get; set; }
    }

    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
