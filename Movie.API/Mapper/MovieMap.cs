using CsvHelper.Configuration;
using Movie.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Mapper
{
    public sealed class MovieMap : ClassMap<Movies>
    {
        public MovieMap()
        {
            Map(x => x.Id).Name("Id");
            Map(x => x.MovieId).Name("MovieId");
            Map(x => x.Title).Name("Title");
            Map(x => x.Language).Name("Language");
            Map(x => x.Duration).Name("Duration");
            Map(x => x.ReleaseYear).Name("ReleaseYear");
        }
        
    }
}
