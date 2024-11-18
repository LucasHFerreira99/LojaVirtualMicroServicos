
using LojaVirtual.Web.Models;
using System.Text.Json;

namespace LojaVirtual.Web.Services.Contracts
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndpoint = "/api/categories/";
        private readonly JsonSerializerOptions _options;
        private CategoryViewModel categoryVM;
        private IEnumerable<CategoryViewModel> categoriesVM;

        public CategoryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            var client = _clientFactory.CreateClient("ProductApi");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    categoriesVM = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return categoriesVM;
        }
    }
}
