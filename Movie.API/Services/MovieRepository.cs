using LINQtoCSV;
using Microsoft.Extensions.Configuration;
using Movie.API.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Services
{
    public class MovieRepository : IMovieRepository
    {

        private IEnumerable<Movies> _movies;
        private IEnumerable<Stats> _stats;
        public MovieRepository()
        {

            _movies = new List<Movies>();
            _movies = GetMoviesList();
            _stats = new List<Stats>();
            _stats = GetStatList();
            //queryFactory.FileName = 
        }

        public async Task<IEnumerable<Movies>> GetAllMoviesWithStats()
        {
            try
            {

                foreach (var item in _movies)
                {
                    item.Stats = new List<Stats>();
                    item.Stats = _stats.Where(x => x.MovieId == item.MovieId).ToList();

                }
                return _movies;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<Movies> GetMoviesById(int movieId)
        {
            return GetMoviesList().Where(x => x.MovieId == movieId).FirstOrDefault();
        }

        public async Task<IEnumerable<Stats>> GetMovieStats()
        {
            return _stats.ToList();
        }

        public async Task<Movies> SaveMovies(Movies movies)
        {
            _movies.Append(new Movies()
            {
                MovieId = movies.MovieId,
                Id = movies.Id,
                Language = movies.Language,
                Duration = movies.Duration,
                ReleaseYear = movies.ReleaseYear,
                Title = movies.Title

            });

            return _movies.LastOrDefault();
        }

        private IList<Movies> GetMoviesList()
        {
            CsvContext cc = new CsvContext();
            var currentDirectory = System.Environment.CurrentDirectory;
            return cc.Read<Movies>(currentDirectory + @"\Files\metadata.csv").ToList();
        }
        private IList<Stats> GetStatList()
        {
            CsvContext cc = new CsvContext();
            var currentDirectory = System.Environment.CurrentDirectory;
            return cc.Read<Stats>(currentDirectory + @"\Files\Stats.csv").ToList();
        }
    }


}
