using LuizaLabs.Service.Interfaces;
using LuizaLabs.Service.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LuizaLabs.Domain.DomainService
{
    public class ProductSearchService : IProductSearchService
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl = "api/product/";

        public ProductSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductServiceModel> GetProductByIdAsync(Guid id)
        {
            try
            {
                string url = $"{_remoteServiceBaseUrl}{id}/";

                var responseString = await _httpClient.GetStringAsync(url);

                var product = JsonConvert.DeserializeObject<ProductServiceModel>(responseString);

                return product;

            } catch(HttpRequestException)
            {
                return null;
            }            
        }
    }
}
