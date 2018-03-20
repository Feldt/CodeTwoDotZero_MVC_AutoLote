using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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



        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();
        }
    }
}