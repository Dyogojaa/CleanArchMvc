using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {

        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult>Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null) 
                return NotFound();

            var categoria = await _categoryService.GetById(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(categoria);
                }
                catch (System.Exception)
                {

                    throw;
                }                
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var categoria = await _categoryService.GetById(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);

        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {   
                await _categoryService.Remove(id);            
                return RedirectToAction("Index");
         
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var categoria = await _categoryService.GetById(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);

        }

    }
}
