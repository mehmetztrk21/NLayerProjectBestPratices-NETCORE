using Microsoft.EntityFrameworkCore;
using NLayerProjectBestPratices.Core.Entity;
using NLayerProjectBestPratices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProjectBestPratices.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private AppDbContext appDbContext{ get => _context as AppDbContext; }
        public ProductRepository(AppDbContext context):base(context)
        {
        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}
