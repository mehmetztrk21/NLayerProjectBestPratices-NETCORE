using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProjectBestPratices.API.DTOs;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()          //AutoMapper kütüphanesi gelen nesneleri DTO nesnelerimize çevirmeye yarar.
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));  //kategorileri kategoriDto ya çevir.
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductById(int id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);
            return Ok(_mapper.Map<CategoryWithProductsDto>(category));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto category)
        {
            var newCategory=await _categoryService.AddAsync(_mapper.Map<Category>(category));
            return Created(string.Empty, _mapper.Map<CategoryDto>(newCategory));  //kayıttan sonra create dön.
        }

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var category = _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return NoContent();  //güncellemeden sonra boş dönme en iyisi.
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;  //.result diyerek asenkron bir metodu normal bir fonksionda böyle kullanabiliriz.
            _categoryService.Remove(category);
            return NoContent();  //silme işleminden sonra da boş dön.
        }

       
    }
}
