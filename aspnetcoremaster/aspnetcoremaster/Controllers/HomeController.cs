﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnetcoremaster.Models;
using aspnetcoremaster.core.Interface;
using aspnetcoremaster.core.Model;

namespace aspnetcoremaster.Controllers
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
            return View(inventoryRepository.All());
        }
        [HttpGet]
        public ActionResult Order()
        {
            return View(new InventoryModel());
        }

        [HttpPost]
        public async Task<IActionResult> Order(InventoryModel data)
        {   
            bool isValidModel = await TryUpdateModelAsync(data);
            if (isValidModel && data.CustomerId != 0)
            {
                inventoryRepository.Insert(data);
                return RedirectPermanent("Index");
            }
            return View(data);


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

    internal class Data
    {
        public bool status { get; set; }
    }
}
