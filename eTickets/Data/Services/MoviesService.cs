using System;
using System.Linq;
using System.Threading.Tasks;

using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) : base(context) => _context = context;

        public async Task<Movie> GetMovieByIdAsync(Int32 id)
        {
            var movieDetails = await _context.MOVIES
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies)
                    .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }


        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.ACTORS.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.CINEMAS.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.PRODUCERS.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }


    }
}

