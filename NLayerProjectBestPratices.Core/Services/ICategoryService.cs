using NLayerProjectBestPratices.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProjectBestPratices.Core.Services
{
    public interface ICategoryService:IGenericService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);


        //sadece özel metotları olan entity lere özel repository ve service interfacelerini oluştur. Diğerlerini direkt Generic ile ulaşabilirsin.
    }
}
