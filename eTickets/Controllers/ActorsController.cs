﻿using System.Collections.Generic;
using System.Threading.Tasks;

using eTickets.Data.Services;
using eTickets.Models;

using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service) => _service = service;

        public async Task<IActionResult> Index()
        {
            IEnumerable<Actor> data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if ( !ModelState.IsValid )
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(System.Int32 id)
        {
            Actor actorDetails = await _service.GetByIdAsync(id);

            return actorDetails == null ? View("NotFound") : View(actorDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(System.Int32 id)
        {
            Actor actorDetails = await _service.GetByIdAsync(id);
            return actorDetails == null ? View("NotFound") : View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(System.Int32 id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if ( !ModelState.IsValid )
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(System.Int32 id)
        {
            Actor actorDetails = await _service.GetByIdAsync(id);
            return actorDetails == null ? View("NotFound") : View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(System.Int32 id)
        {
            Actor actorDetails = await _service.GetByIdAsync(id);
            if ( actorDetails == null )
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}