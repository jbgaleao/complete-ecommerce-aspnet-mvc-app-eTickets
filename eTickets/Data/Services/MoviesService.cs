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
        #region Construtor e ID
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion


        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            //  Add Movie
            //  =============================================================
            Movie newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
            await _context.MOVIES.AddAsync(newMovie);
            await _context.SaveChangesAsync();



            //  Add Movie Actors
            //  =============================================================
            foreach (int actorId in data.ActorIds)
            {
                Actor_Movie newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.ACTORS_MOVIES.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }



        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            Movie movieDetails = await _context.MOVIES
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies)
                    .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }


        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            NewMovieDropdownsVM response = new NewMovieDropdownsVM()
            {
                Actors = await _context.ACTORS.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.CINEMAS.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.PRODUCERS.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }


    }
}

