using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Etiket.Data;
using Etiket.Data.Services;
using Etiket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Etiket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersServices _services;

        public ProducersController(IProducersServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var allproducer = await _services.GetAllAsync();
            return View(allproducer);
        }

        //get: create
        public ActionResult Create()
        {
            return View();
        }
        //post:Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName", "ProfilePictureURL", "Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _services.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        //------------------------------------------------//

        //Get:/detail/1

        public async Task<IActionResult> Details(int id)
        {
            var producersDetails = await _services.GetByIdAsync(id);

            if (producersDetails == null) return View("NotFound");

            return View(producersDetails);
        }
        //------------------------------------------------//

        //Get: Edit

        public async Task<ActionResult> Edit(int id)
        {

            var producersEdit = await _services.GetByIdAsync(id);

            if (producersEdit == null) return View("NotFound");

            return View(producersEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "FullName", "ProfilePictureURL", "Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _services.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }
        //------------------------------------------------//


        //Delete 
        public async Task<ActionResult> Delete(int id)
        {

            var producerEdit = await _services.GetByIdAsync(id);
            if (producerEdit == null) return View("NotFound");

            return View(producerEdit);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerEdit = await _services.GetByIdAsync(id);
            if (producerEdit == null) return View("NotFound");
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        //------------------------------------------------//
    }
}