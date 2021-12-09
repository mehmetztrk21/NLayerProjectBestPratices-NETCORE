using Microsoft.EntityFrameworkCore;
using NLayerProjectBestPratices.Core.Entity;
using NLayerProjectBestPratices.Data.Configurations;
using NLayerProjectBestPratices.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProjectBestPratices.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> Persons { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //veri tabanı tablosu ayarlarını burda yapıyoruz.
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

           //seed dataları yüklemek için
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));


            modelBuilder.Entity<Person>().HasKey(i => i.Id);
            modelBuilder.Entity<Person>().Property(i => i.Id).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(i => i.Name).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(i => i.Surname).HasMaxLength(100);

        }

    }
}
