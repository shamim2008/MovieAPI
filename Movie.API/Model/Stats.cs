using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Model
{
    public class Stats
    {
        [CsvColumn(FieldIndex = 1,Name = "movieId")]
        public int MovieId { get; set; }
        [CsvColumn(FieldIndex = 2, Name = "watchDurationMs")]
        public double? WatchDuration { get; set; }

    }
}
