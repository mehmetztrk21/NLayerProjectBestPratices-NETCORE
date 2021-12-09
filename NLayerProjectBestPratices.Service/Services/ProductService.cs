using NLayerProjectBestPratices.Core.Entity;
using NLayerProjectBestPratices.Core.Repositories;
using NLayerProjectBestPratices.Core.Services;
using NLayerProjectBestPratices.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProjectBestPratices.Service.Services
{
    public class ProductService : GenericService<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
