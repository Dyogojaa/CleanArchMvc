using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetProducts();

            return Ok(products);

        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var produto = await _productService.GetById(id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest("Dados Inválidos");
            }
            await _productService.Add(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] ProductDTO productDTO, int id)
        {

            if (id != productDTO.Id)
                return BadRequest("Dados Inválidos");

            if (productDTO == null)
                return BadRequest("Dados Inválidos");

            await _productService.Update(productDTO);

            return Ok(productDTO);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {

            var produto = await _productService.GetById(id);

            if (produto == null)
            {
                return NotFound("Produto não encontrada!");
            }

            await _productService.Remove(id);

            return Ok(produto);

        }

    }
}
