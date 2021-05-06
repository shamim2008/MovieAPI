using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.Model
{


    public class Movies
    {

        [CsvColumn(FieldIndex = 1)]
        public int? Id { get; set; }
        [CsvColumn(FieldIndex = 2)]
        public int MovieId { get; set; }
        [CsvColumn(FieldIndex = 3)]
        public string Title { get; set; }
        [CsvColumn(FieldIndex = 4)]
        public string Language { get; set; }
        [CsvColumn(FieldIndex = 5, OutputFormat = "HH:mm:ss")]
        public TimeSpan Duration { get; set; }
        [CsvColumn(FieldIndex = 6)]
        public int? ReleaseYear { get; set; }
        public virtual IList<Stats>? Stats { get; set; }

    }
}
