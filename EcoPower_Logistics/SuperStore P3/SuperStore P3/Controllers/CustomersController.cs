///29496470, Richard Akinkunmi
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
    public class CustomersController : Controller
    {
        private readonly ICustomersRepository customersRepo;

        public CustomersController(ICustomersRepository customersRepository)
        {
            customersRepo = customersRepository;
        }

        // GET: Customers
        public IActionResult Index()
        {
            var customers = customersRepo.GetAll();
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customersRepo.GetById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customersRepo.Add(customer);
                // You might want to add error handling and validation here.
                // Also, consider returning a different view or redirecting to a different action on failure.
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customersRepo.GetById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    customersRepo.Update(customer);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customersRepo.GetById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = customersRepo.GetById(id);

            if (customer != null)
            {
                customersRepo.Remove(customer);
                // Handle exceptions and validation if necessary.
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }


        private bool CustomerExists(int id)
        {
            return customersRepo.GetById(id) != null;
        }


    }
}