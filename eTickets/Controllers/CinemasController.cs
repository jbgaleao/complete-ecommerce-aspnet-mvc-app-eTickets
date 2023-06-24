using System.Collections.Generic;
using System.Threading.Tasks;

using eTickets.Data.Services;
using eTickets.Models;

using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{

    public class CinemasController : Controller
    {
        #region Construtor e Injeção de Dependencia

        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service) => _service = service;

        #endregion

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Cinema> allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if ( !ModelState.IsValid )
                return View(cinema);

            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(System.Int32 id)
        {
            Cinema cinemaDetails = await _service.GetByIdAsync(id);
            return cinemaDetails == null ? View("NotFound") : View(cinemaDetails);
        }

        //Get: Cinema/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(System.Int32 id)
        {
            Cinema cinemaDetails = await _service.GetByIdAsync(id);
            return cinemaDetails == null ? View("NotFound") : View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(System.Int32 id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if ( !ModelState.IsValid )
            {
                return View(cinema);
            }
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinema/Delete/1
        [HttpGet]
        public async Task<IActionResult> Delete(System.Int32 id)
        {
            Cinema cinemaDetails = await _service.GetByIdAsync(id);
            return cinemaDetails == null ? View("NotFound") : View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(System.Int32 id)
        {
            Cinema cinemaDetails = await _service.GetByIdAsync(id);
            if ( cinemaDetails == null )
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
