using Newtonsoft.Json;
using NLayerProjectBestPratices.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProjectBestPratices.Web.ApiService
{
    public class CategoryApiService     //category api ye bağlanmak için oluşturduğumuz sınıf. Bu sınıfı startrup ınıfından çağırdık.
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDtos;
            var response = await _httpClient.GetAsync("category");
            if (response.IsSuccessStatusCode)
            {
                categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync());

            }
            else
            {
                categoryDtos = null;
            }
            return categoryDtos;
        }
        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto),Encoding.UTF8,"application/json");  //nesneyi jsona dönüştürme
            var response = await _httpClient.PostAsync("category", stringContent);
            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync());//jsonu nesneye dönüştürme.
                return categoryDto; 
            }
            return null;
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"category/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
        
        public async Task<bool> Update(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json");
            var response = _httpClient.PutAsync("category", stringContent);
            if (response.IsCompletedSuccessfully)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"category/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }

  
}
