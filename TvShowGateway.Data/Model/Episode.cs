using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvShowGateway.Data.Model
{
    public class Episode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EpisodeId { get; set; }

        public TvShow TvShow { get; set; }

        [ForeignKey(nameof(TvShow))]
        public long TvShowId { get; set; } 

        public int SeasonNumber { get; set; }

        public int EpisodeNumber { get; set; }

        public string Summary { get; set; }
    }
}
