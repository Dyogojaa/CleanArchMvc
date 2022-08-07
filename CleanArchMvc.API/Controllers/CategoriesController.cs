using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
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
            var categories = await _categoryService.GetCategories();

            if (categories == null)
            {
                return NotFound("Categorias não encontradas!");
            }
            return Ok(categories);
        }

        [HttpGet("{id:int}",Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound("Categoria não encontrada!");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                return BadRequest("Dados Inválidos");

            await _categoryService.Add(categoryDTO);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);

        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CategoryDTO categoryDTO, int id)
        {
            
            if (id != categoryDTO.Id)
                return BadRequest("Dados Inválidos");

            if (categoryDTO == null)
                return BadRequest("Dados Inválidos");

            await _categoryService.Update(categoryDTO);

            return Ok(categoryDTO);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound("Categoria não encontrada!");
            }

            await _categoryService.Remove(id);

            return Ok(category);

        }
    }
}
