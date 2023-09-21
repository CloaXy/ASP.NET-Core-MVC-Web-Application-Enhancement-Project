using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using EcoPower_Logistics.Repository;
using System.Linq.Expressions;
using NuGet.Protocol;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository productsRepo;

        public ProductsController(IProductsRepository productsRepository)
        {
            productsRepo = productsRepository;
        }

        // GET: Products
        public IActionResult Index()
        {
            var products = productsRepo.GetAll();
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = productsRepo.GetById(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductTitle,ProductName,ProductSurname,CellPhone")] Product product)
        {
            if (ModelState.IsValid)
            {
                productsRepo.Add(product);
                // You might want to add error handling and validation here.
                // Also, consider returning a different view or redirecting to a different action on failure.
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = productsRepo.GetById(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(" ProductId, ProductName, ProductDescription, UnitsInStock")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productsRepo.Update(product);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = productsRepo.GetById(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = productsRepo.GetById(id);

            if (product != null)
            {
                productsRepo.Remove(product);
                // Handle exceptions and validation if necessary.
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        private bool ProductExists(int id)
        {
            return productsRepo.GetById(id) != null;
        }


    }
}