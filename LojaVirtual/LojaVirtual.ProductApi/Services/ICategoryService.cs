﻿using LojaVirtual.ProductApi.DTOs;

namespace LojaVirtual.ProductApi.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();    
        Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();    
        Task<CategoryDTO> GetCategoryById(int id);    
        Task AddCategory(CategoryDTO categoryDTO);
        Task UpdateCategory(CategoryDTO categoryDTO);
        Task RemoveCategory(int id);
    }
}
