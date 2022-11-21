using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Etiket.Data;
using Etiket.Data.Services;
using Etiket.Models;
using Microsoft.AspNetCore.Mvc;

namespace Etiket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsServices _services;

        public ActorsController(IActorsServices services)
        {
            _services = services;
        }
        //list all
        public async Task<IActionResult> Index()
        {
            var data = await _services.GetAllAsync();
            return View(data);
        }
        //------------------------------------------------//

        //get: create
        public ActionResult Create()
        {
            return View();
        }
        //post:Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName", "ProfilePictureURL", "Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

           await _services.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        //------------------------------------------------//

        //Get: Actors/detail/1

        public async Task<IActionResult> Details(int id)
        {
            var actosDetails = await _services.GetByIdAsync(id);

            if (actosDetails == null) return View("NotFound");
           
            return View(actosDetails);
        }
        //------------------------------------------------//

        //Get: Edit

        public async Task<ActionResult> Edit(int id)
        {

            var actosEdit= await _services.GetByIdAsync(id);

            if (actosEdit == null) return View("NotFound");

            return View(actosEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id","FullName", "ProfilePictureURL", "Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _services.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }
        //------------------------------------------------//


        //Delete 
        public async Task<ActionResult> Delete(int id)
        {

            var actosEdit = await _services.GetByIdAsync(id);
            if (actosEdit == null) return View("NotFound");

            return View(actosEdit);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actosEdit = await _services.GetByIdAsync(id);
            if (actosEdit == null) return View("NotFound");
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        //------------------------------------------------//
    }
}