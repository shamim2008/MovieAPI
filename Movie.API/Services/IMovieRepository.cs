using Movie.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Movie.API.Services
{
    public interface IMovieRepository
    {
        Task<Movies> SaveMovies(Movies movies);
        Task<Movies> GetMoviesById(int movieId);
        Task<IEnumerable<Movies>> GetAllMoviesWithStats();
        Task<IEnumerable<Stats>> GetMovieStats();

    }
}
