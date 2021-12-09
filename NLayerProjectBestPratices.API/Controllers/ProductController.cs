using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProjectBestPratices.API.DTOs;
using NLayerProjectBestPratices.API.Filters;
using NLayerProjectBestPratices.Core.Entity;
using NLayerProjectBestPratices.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProjectBestPratices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task< IActionResult> ProductWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }

        [ValidationFilter]  //hata mesajları için
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Created(string.Empty, _mapper.Map<ProductDto>(product));
        }
        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            if (string.IsNullOrEmpty(productDto.Id.ToString()) || productDto.Id <= 0)  //default 0 id veriyor eğer 0 dan küçükse veya boşsa yeni bir hata mesajı oluştur diyoruz. Bu hata mesajının cliente gönderimini startup dosyasında yapıyoruz incele. Startup dosyasından Extensions klasöründe yazdığımız kodları çağırıyoruz. UseCustomExtencionHandler içindeki fonksiyonu çağırıyoruz yani.
            {
                throw new Exception("Id alanı gereklidir.");
            }
            var product = _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);
            return NoContent();
        }

    }
}
