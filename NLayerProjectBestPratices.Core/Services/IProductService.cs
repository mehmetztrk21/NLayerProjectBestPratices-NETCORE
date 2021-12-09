using NLayerProjectBestPratices.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProjectBestPratices.Core.Services
{
    public interface IProductService:IGenericService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);


        //veri tabanı ile ilgili olmayan product fonksiyonları da service interface lerinde tanımlanır.
    }
}
