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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }

        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await appDbContext.Categories.Include(X => X.Products).SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
