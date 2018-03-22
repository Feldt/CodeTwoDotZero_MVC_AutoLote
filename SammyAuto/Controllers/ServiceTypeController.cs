using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SammyAuto.Data;

namespace SammyAuto.Models
{
    public class ServiceTypeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ServiceTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //get: servicesTypes
        public IActionResult Index()
        {
            return View(_db.ServiceTypes.ToList());
        }

        //get: serviceType/create
        public IActionResult Create()
        {
            return View();
        }
        //post: services/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceType serviceTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Add(serviceTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceTypes);
        }

        //Details: servicetype/details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
                return NotFound();

            return View(serviceType);
        }


        //Edit: servicetype/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
                return NotFound();

            return View(serviceType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, ServiceType service)
        {
            if (id != service.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _db.Update(service);
                await _db.SaveChangesAsync();
              return  RedirectToAction(nameof(Index));
            }
            return View(service);
        }


        //Delete: servicetype/delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
                return NotFound();

            return View(serviceType);
        }

        [HttpPost, ActionName("Detele")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveService(int id)
        {
            var service = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);

            _db.ServiceTypes.Remove(service);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();
        }
    }
}