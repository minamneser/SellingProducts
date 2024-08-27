using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SellingProducts.Data;
using SellingProducts.Models;
using SellingProducts.Services.ProductServices;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SellingProducts.Controllers
{    
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _host;
        private readonly IProductService _productService;

        public ProductsController(AppDbContext context , IHostingEnvironment host,IProductService productService)
        {
            _context = context;
            _host = host;
            this._productService = productService;
        }
        public IActionResult Index()
        {
            //IEnumerable<Product> productsList = _context.Products.Include(c => c.Category).ToList();
            var productList = _productService.GetAll();
            //Test
            return View(productList);
        }
        [Authorize]
        public IActionResult Create()
        {
            createSelectList();
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (product.ClientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    fileName = product.ClientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    product.ClientFile.CopyTo(new FileStream(fullPath,FileMode.Create));
                    product.Image = fileName;
                }

                _context.Products.Add(product);
                _context.SaveChanges();
                TempData["successData"] = "Item has been created";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        [Authorize]
        public void createSelectList(int selectId = 0)
        {
            List<Category> categories = _context.Categories.ToList();
            SelectList listItems = new SelectList(categories,"Id","Name",selectId);
            ViewBag.CategoryList = listItems;
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            Product product =_context.Products.FirstOrDefault(c => c.Id == id)!;
            if (product == null)
            {
                 return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            TempData["errorData"] = "Item has been deleted";
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var productVM = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                CategoryId = product.CategoryId,
                CreatedDate = DateTime.Now,
            };
            createSelectList(product.CategoryId);
            return View(productVM);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, Product product)
        {
            var products = _context.Products.FirstOrDefault(x => x.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            products.Name = product.Name;
            products.Price = product.Price;
            products.Category = product.Category;
            products.CategoryId = product.CategoryId;
            products.CreatedDate = DateTime.Now;
            _context.SaveChanges();
            TempData["updatedData"] = "Item has been Updated";
            return RedirectToAction("Index");
        }
        
        public IActionResult Details(int id)
        {
            Product product =_context.Products.FirstOrDefault(x => x.Id == id)!;
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
