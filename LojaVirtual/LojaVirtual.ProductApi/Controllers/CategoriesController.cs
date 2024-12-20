﻿using LojaVirtual.ProductApi.DTOs;
using LojaVirtual.ProductApi.Roles;
using LojaVirtual.ProductApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoriesDto = await _categoryService.GetCategories();
            if (categoriesDto is null)
                return NotFound("Categories not found");

            return Ok(categoriesDto);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProduct()
        {
            var categoriesDto = await _categoryService.GetCategoriesProducts();
            if (categoriesDto is null)
                return NotFound("Categories not found");

            return Ok(categoriesDto);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get( int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category is null)
                return NotFound("Category not found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto is null)
                return BadRequest("Invalid Data");

            await _categoryService.AddCategory(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new {id = categoryDto.CategoryId}, categoryDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.CategoryId)
                return BadRequest();

            if (categoryDto is null)
                return BadRequest();

            await _categoryService.UpdateCategory(categoryDto);
            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);
            if (categoryDto == null)
                return NotFound("Category not found");

            await _categoryService.RemoveCategory(id);
            return Ok(categoryDto);
        }
    }
}
