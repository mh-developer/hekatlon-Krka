﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models;
using WebApp.Models;
using WebApp.Models.Delivery;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Authorize]
    public class DeliveriesController : Controller
    {
        private readonly ILogger<WarehousesController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IWarehouseService _warehouseService;
        private readonly IDeliveryService _deliveryService;
        private readonly IDeliveryPointService _deliveryPointService;
        private readonly ICompanyService _companyService;
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        public DeliveriesController(
            ILogger<WarehousesController> logger,
            IAuthenticationSchemeProvider schemeProvider,
            UserManager<User> userManager,
            IUserService userService,
            IWarehouseService warehouseService,
            IDeliveryService deliveryService,
            IDeliveryPointService deliveryPointService,
            ICompanyService companyService)
        {
            _logger = logger;
            _userManager = userManager;
            _userService = userService;
            _warehouseService = warehouseService;
            _deliveryService = deliveryService;
            _deliveryPointService = deliveryPointService;
            _companyService = companyService;
            _schemeProvider = schemeProvider;
        }

        // GET: Deliveries
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var company = await _companyService.GetAsync((Guid) user.CompanyId);

            var vm = new DeliveryViewModel
            {
                DeliveriesInProgress = await _deliveryService.GetAllAsync(),
                DeliveriesRequests = await _deliveryService.GetAllAsync(),
                DestinationCompanies = company
            };

            return View(vm);
        }

        // GET: Deliveries/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _deliveryService.GetAsync((Guid) id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // GET: Deliveries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeliveryDto delivery)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    var sourceCompany = await _companyService.GetByNameAsync(delivery.SourceCompany.Name);

                    var newDelivery = new DeliveryDto()
                    {
                        Id = Guid.NewGuid(),
                        CreationTime = DateTime.UtcNow,
                        DestinationCompanyId = user.CompanyId,
                        SourceCompanyId = sourceCompany.Id,
                        Code = delivery.Code,
                        Status = DeliveryStatus.None
                    };

                    await _deliveryService.CreateAsync(newDelivery);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, "Podjetje s takšnim imenom ne obstaja. Navedite točno ime.");
                    return View(delivery);
                }
            }

            return View(delivery);
        }

        // GET: Deliveries/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _deliveryService.GetAsync((Guid) id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,
            [Bind("Code,Status,DispatchTime,DeliveryTime,Id")]
            DeliveryDto delivery)
        {
            if (id != delivery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _deliveryService.UpdateAsync(delivery);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await DeliveryExists(delivery.Id))
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

            return View(delivery);
        }


        // GET: Deliveries/Delete/5
        public async Task<IActionResult> Dispatch(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var delivery = await _deliveryService.GetAsync((Guid) id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var company = await _companyService.GetAsync((Guid) user.CompanyId);

            try
            {
                var warehouse = (await _warehouseService.GetAllAsync()).Where(x =>
                    x.CompanyId == company.Id && x.MaxCode >= delivery.Code && x.MinCode <= delivery.Code).FirstOrDefault();

                var deliveryPoints = (await _deliveryPointService.GetAllAsync()).Where(x => x.WarehouseId == warehouse.Id)
                    .ToList();

                var deliveryEvents = new List<Event>();

                deliveryPoints.ForEach((x) =>
                {
                    var deliveries = _deliveryService.GetAllAsync().GetAwaiter().GetResult().Where(o => o.DeliveryPointId == x.Id).ToList();

                    deliveries.ForEach(d =>
                    {
                        deliveryEvents.Add(new Event()
                        {
                            Title = "Dostava",
                            Start = d.DispatchTime,
                            End = d.DeliveryTime
                        });
                    });
                });

                var vm = new DeliveryViewModel()
                {
                    Id = delivery.Id,
                    Code = delivery.Code,
                    DestinationCompanies = company,
                    DeliveryPoints = deliveryPoints,
                    DeliveryEvents = deliveryEvents
                };

            if (vm == null)
            {
                return NotFound();
            }

            return View(vm);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Prosimo vnesite skladišča (tudi min in max vrednost posebej) in dostavne točke, ter nato poskusite ponovno.");
                
                return View(new DeliveryViewModel()
                {
                    Id = delivery.Id,
                    Code = delivery.Code,
                    DestinationCompanies = company,
                    DeliveryPoints = new List<DeliveryPointDto>(),
                    DeliveryEvents = new List<Event>()
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dispatch(Guid? id, DeliveryDto delivery)
        {
            if (id != delivery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var newDelivery = await _deliveryService.GetAsync((Guid) id);

                    newDelivery.DeliveryTime = delivery.DeliveryTime;
                    newDelivery.DispatchTime = delivery.DispatchTime;
                    newDelivery.DeliveryPointId = delivery.DeliveryPointId;
                    newDelivery.Status = DeliveryStatus.InProgress;

                    await _deliveryService.UpdateAsync(newDelivery);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await DeliveryExists(delivery.Id))
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

            return View(delivery);
        }


        public async Task<IActionResult> Accept(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _deliveryService.GetAsync((Guid) id);
            if (delivery == null)
            {
                return NotFound();
            }

            try
            {
                delivery.Status = DeliveryStatus.Received;
                await _deliveryService.UpdateAsync(delivery);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DeliveryExists(delivery.Id))
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

        // GET: Deliveries/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _deliveryService.GetAsync((Guid) id);

            await _deliveryService.RemoveAsync(delivery.Id);
            
            return RedirectToAction(nameof(Index));
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _deliveryService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DeliveryExists(Guid id)
        {
            return (await _deliveryService.GetAllAsync()).Any(e => e.Id == id);
        }
    }
}