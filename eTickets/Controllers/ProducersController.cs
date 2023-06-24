﻿using System.Collections.Generic;
using System.Threading.Tasks;

using eTickets.Data.Services;
using eTickets.Models;

using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service) => _service = service;

        public async Task<IActionResult> Index()
        {
            IEnumerable<Producer> allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        [HttpGet]
        public async Task<IActionResult> Details(System.Int32 id)
        {
            Producer producerDetails = await _service.GetByIdAsync(id);
            return producerDetails == null ? View("NotFound") : View(producerDetails);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if ( !ModelState.IsValid )
            {
                return View(producer);
            }

            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(System.Int32 id)
        {
            Producer producerDetails = await _service.GetByIdAsync(id);
            return producerDetails == null ? View("NotFound") : View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(System.Int32 id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if ( !ModelState.IsValid )
            {
                return View(producer);
            }

            if ( id == producer.Id )
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }

            return View(producer);
        }







        [HttpGet]
        public async Task<IActionResult> Delete(System.Int32 id)
        {
            Producer producerDetails = await _service.GetByIdAsync(id);
            return producerDetails == null ? View("NotFound") : View(producerDetails);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(System.Int32 id)
        {
            Producer producerDetails = await _service.GetByIdAsync(id);
            if ( producerDetails == null )
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }




    }
}
