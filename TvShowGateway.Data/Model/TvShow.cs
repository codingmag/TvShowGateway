using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvShowGateway.Data.Model
{
    public class TvShow
    {
        [Key]
        public int TvShowId { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }

        public string Summary { get; set; }

        public List<Episode> Episodes { get; set; }
    }
}
