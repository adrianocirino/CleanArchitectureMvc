using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitectureMvc.Application.DTOs;
using CleanArchitectureMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var categories = await _categoryService.GetCategoriesAsync();

            if (categories == null) return NoContent();

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null) return NotFound("Category not found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post(CategoryDTO categoryDto)
        {
            if (categoryDto == null) return BadRequest();
            
            if (!ModelState.IsValid) return BadRequest();

            await _categoryService.Add(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new {id = categoryDto.Id}, categoryDto);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> Put(int id, CategoryDTO categoryDto)
        {
            if (categoryDto == null) return BadRequest();

            if (id != categoryDto.Id) return BadRequest();


            await _categoryService.Update(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null) return NotFound();

            await _categoryService.Remove(id);
            
            return Ok(category);
        }
    }
}
