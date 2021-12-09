using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProjectBestPratices.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProjectBestPratices.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Pilot Kalem", Price = 12.20m, Stock = 100, CategoryId = _ids[0] },
                  new Product { Id = 2, Name = "Kurşun Kalem", Price = 12.50m, Stock = 200, CategoryId = _ids[0] },
                    new Product { Id = 3, Name = "Tükenmez Kalem", Price = 18.20m, Stock = 1000, CategoryId = _ids[0] },
                      new Product { Id = 4, Name = "Küçük Boy Defter", Price = 19.50m, Stock = 150, CategoryId = _ids[1] },
                        new Product { Id = 5, Name = "Büyük Boy Defter", Price = 12.20m, Stock = 90, CategoryId = _ids[1] }
                );
        }
    }
}
