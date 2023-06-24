using System;
using System.Threading.Tasks;

using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(Int32 id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
    }
}
