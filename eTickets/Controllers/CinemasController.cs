using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Controllers
{

    public class CinemasController : Controller
    {
        #region Construtor e Injeção de Dependencia

        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        #endregion


        public async Task<IActionResult> Index()
        {
            IEnumerable<Cinema> allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }
    }
}
