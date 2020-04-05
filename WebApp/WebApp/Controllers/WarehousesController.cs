﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class WarehousesController : Controller
    {
        private readonly ILogger<WarehousesController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IWarehouseService _warehouseService;
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        public WarehousesController(
            ILogger<WarehousesController> logger,
            IAuthenticationSchemeProvider schemeProvider,
            UserManager<User> userManager,
            IUserService userService,
            IWarehouseService warehouseService)
        {
            _logger = logger;
            _userManager = userManager;
            _userService = userService;
            _warehouseService = warehouseService;
            _schemeProvider = schemeProvider;
        }

        // GET: Warehouses
        public async Task<IActionResult> Index()
        {
            return View(await _warehouseService.GetAllAsync());
        }

        // GET: Warehouses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = await _warehouseService.GetAsync((Guid) id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        // GET: Warehouses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Warehouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MinCode,MaxCode,Name,Address,PhoneNumber")]
            WarehouseDto warehouse)
        {
            if (ModelState.IsValid)
            {
                warehouse.Id = Guid.NewGuid();
                await _warehouseService.CreateAsync(warehouse);
                return RedirectToAction(nameof(Index));
            }

            return View(warehouse);
        }

        // GET: Warehouses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = await _warehouseService.GetAsync((Guid) id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        // POST: Warehouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MinCode,MaxCode,Name,Address,PhoneNumber,Id")]
            WarehouseDto warehouse)
        {
            if (id != warehouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _warehouseService.UpdateAsync(warehouse);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await WarehouseExists(warehouse.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(warehouse);
        }

        // GET: Warehouses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = await _warehouseService.GetAsync((Guid) id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        // POST: Warehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _warehouseService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> WarehouseExists(Guid id)
        {
            var warehouse = await _warehouseService.GetAllAsync();
            return warehouse.Any(e => e.Id == id);
        }
    }
}