namespace TvShowGateway.Service.Episode
{
    public class EpisodeModel
    {
        public long EpisodeId { get; set; }

        public int TvShowId { get; set; }

        public int SeasonNumber { get; set; }

        public int EpisodeNumber { get; set; }

        public string Summary { get; set; }
    }
}
