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
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository ordersRepo;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            ordersRepo = ordersRepository;
        }

        // GET: Orders
        public IActionResult Index()
        {
            var orders = ordersRepo.GetAll();
            return View(orders.ToList());
        }

        // GET: Order/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = ordersRepo.GetById(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Order order)
        {
            if (ModelState.IsValid)
            {
                ordersRepo.Add(order);
                // You might want to add error handling and validation here.
                // Also, consider returning a different view or redirecting to a different action on failure.
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Order/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = ordersRepo.GetById(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ordersRepo.Update(order);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = ordersRepo.GetById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = ordersRepo.GetById(id);

            if (customer != null)
            {
                ordersRepo.Remove(customer);
                // Handle exceptions and validation if necessary.
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }


        private bool OrderExists(int id)
        {
            return ordersRepo.GetById(id) != null;
        }


    }
}