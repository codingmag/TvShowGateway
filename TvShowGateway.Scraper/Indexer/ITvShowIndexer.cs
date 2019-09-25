using System.Threading.Tasks;

namespace TvShowGateway.Scraper.Indexer
{
    public interface ITvShowIndexer
    {
        Task IndexTvShowsWithEpisodesAsync(string searchTerm);
    }
}
