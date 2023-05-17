using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        //var p = new Product() { ProductFeature = new ProductFeature() };  böyle de productFeature üzerinde işlemler yapılabilir.


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //çalışmadaki bütün configuration dosyalarını yap demek.
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());//veya böyle tek tek bütün config dosyalarını ekleyebiliriz.
            base.OnModelCreating(modelBuilder);
        }

    }
}
