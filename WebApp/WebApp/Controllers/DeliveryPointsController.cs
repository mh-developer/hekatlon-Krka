﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WebApp.Domain.Models;
using WebApp.Infrastructure;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Authorize]
    public class DeliveryPointsController : Controller
    {
        private readonly ILogger<DeliveryPointsController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IWarehouseService _warehouseService;
        private readonly IDeliveryPointService _deliveryPointService;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly ICompanyService _companyService;
        private readonly ApplicationDbContext _context;

        public DeliveryPointsController(
            ILogger<DeliveryPointsController> logger,
            IAuthenticationSchemeProvider schemeProvider,
            UserManager<User> userManager,
            IUserService userService,
            IDeliveryPointService deliveryPointService,
            IWarehouseService warehouseService,
            ICompanyService companyService,
            ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _userService = userService;
            _warehouseService = warehouseService;
            _deliveryPointService = deliveryPointService;
            _schemeProvider = schemeProvider;
            _companyService = companyService;
            _context = context;
        }

        // GET: DeliveryPoints
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DeliveryPoints.Include(d => d.Warehouse);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeliveryPoints/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryPoint = await _context.DeliveryPoints
                .Include(d => d.Warehouse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryPoint == null)
            {
                return NotFound();
            }

            return View(deliveryPoint);
        }

        // GET: DeliveryPoints/Create
        public IActionResult Create()
        {
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Name");
            return View();
        }

        // POST: DeliveryPoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,WarehouseId,Address,PhoneNumber,Id,IsDeleted,DeletionTime")] DeliveryPoint deliveryPoint)
        {
            if (ModelState.IsValid)
            {
                deliveryPoint.Id = Guid.NewGuid();
                _context.Add(deliveryPoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Name", deliveryPoint.WarehouseId);
            return View(deliveryPoint);
        }

        // GET: DeliveryPoints/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryPoint = await _context.DeliveryPoints.FindAsync(id);
            if (deliveryPoint == null)
            {
                return NotFound();
            }
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Name", deliveryPoint.WarehouseId);
            return View(deliveryPoint);
        }

        // POST: DeliveryPoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,WarehouseId,Address,PhoneNumber,Id,IsDeleted,DeletionTime")] DeliveryPoint deliveryPoint)
        {
            if (id != deliveryPoint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryPoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryPointExists(deliveryPoint.Id))
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
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Name", deliveryPoint.WarehouseId);
            return View(deliveryPoint);
        }

        // GET: DeliveryPoints/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryPoint = await _deliveryPointService.GetAsync((Guid)id);
            await _deliveryPointService.RemoveAsync(deliveryPoint.Id);
            
            return RedirectToAction(nameof(Index));
        }

        // POST: DeliveryPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var deliveryPoint = await _context.DeliveryPoints.FindAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryPointExists(Guid id)
        {
            return _context.DeliveryPoints.Any(e => e.Id == id);
        }
    }
}
