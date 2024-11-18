using LojaVirtual.Web.Models;

namespace LojaVirtual.Web.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();
    }
}
