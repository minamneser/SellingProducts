using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellingProducts.Models;
using SellingProducts.Repository.Base;

namespace SellingProducts.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGenericRepository<Category> _repository;
        public CategoryController(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }
        [Authorize]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var c = new Category
                {
                    Name = category.Name,
                    Id = category.Id,
                };
                var categoryModel = _repository.Create(category);
                return RedirectToAction("Index");                
            }
            else
            {
                return View(category);
            }            
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var cat = _repository.GetById(id);
            if (cat == null)
            {
                return View("Error");
            }
            var newCat = new Category
            {
                Name = cat.Name,
                Id = cat.Id,
            };
            return View(newCat);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var c = new Category
                {
                    Name = category.Name,
                    Id = category.Id,
                };
                var categoryModel = _repository.Edit(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }

        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var c = _repository.GetById(id);
            _repository.Delete(c);
            return RedirectToAction("Index");
        }
        
    }
}
