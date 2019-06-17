﻿using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace SportStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Products);

        public ViewResult Edit(int productId) => View(repository.Products
            .FirstOrDefault(p => p.ProductID == productId));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "there is something wrong with data values";
                return View(product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productID)
        {
            Product deleteProduct = repository.DeleteProduct(productID);
            if (deleteProduct != null)
            {
                TempData["message"] = $"{deleteProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

        //may delete if it isn't work
        //[HttpPost]
        //public IActionResult SeedDatabase()
        //{
        //    SeedData.EnsurePopulated(HttpContext.RequestServices);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
