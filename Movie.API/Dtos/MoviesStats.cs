using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Dtos
{
    public class MoviesStats
    {
        public string MovieName { get; set; }
        public int? Duration { get; set; }
        public int? AverageDuration { get; set; }
        public int? TotalWatch { get; set; }
    }
}
