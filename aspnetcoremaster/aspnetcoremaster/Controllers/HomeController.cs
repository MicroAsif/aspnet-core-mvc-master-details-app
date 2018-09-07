using System.Diagnostics;
using System.Linq;
using aspnetcoremaster.core.Interface;
using aspnetcoremaster.core.Model;
using aspnetcoremaster.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoremaster.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IInventoryRepository inventoryRepository;

        public HomeController(IProductRepository productRepository, ICategoryRepository categoryRepository,
                              ICustomerRepository customerRepository, IInventoryRepository inventoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.customerRepository = customerRepository;
            this.inventoryRepository = inventoryRepository;
        }
        public IActionResult Index()
        {
            return View(inventoryRepository.All().Take(7));
        }
        [HttpGet]
        public ActionResult Order()
        {
            return View(new InventoryModel());
        }

        [HttpPost]
        public JsonResult Order(InventoryModel data)
        {
            //doesn't redirect where it should redirect
            if (ModelState.IsValid && data.CustomerId != 0)
            {
                inventoryRepository.Insert(data);
                TempData["Msg"] = "Order Saved Successfully ";
                return Json(new { redirectToUrl = Url.Action("Index", "Home")});
            }
            TempData["Msg"] = "Failed to save order !";
            return Json(new { redirectToUrl = Url.Action("Index", "Home") });

        }
        public IActionResult CustomerList()
        {
            return View(customerRepository.All()); 
        }
        public IActionResult CategoryList()
        {
            return View(categoryRepository.All()); 
        }
        public IActionResult ProductList()
        {
            return View(productRepository.All());
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public JsonResult Customers()
        {
            return Json(customerRepository.All());
        }
        public JsonResult GetCategories()
        {
            return Json(categoryRepository.All());
        }
        public JsonResult GetProducts(int categoryId = 0)
        {
            if (categoryId == 0)
                return Json(productRepository.All());
            return Json(productRepository.All().Where(x => x.CategoryId == categoryId));
        }
        public JsonResult GetProductById(int productId)
        {
            return Json(productRepository.All().Where(x => x.Id == productId));
        }
    }
}
