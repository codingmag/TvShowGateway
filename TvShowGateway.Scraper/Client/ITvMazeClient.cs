using System.Collections.Generic;
using System.Threading.Tasks;
using TvShowGateway.Scraper.Model;

namespace TvShowGateway.Scraper.Client
{
    public interface ITvMazeClient
    {
        Task<List<ShowSearchResult>> GetShowsAsync(string searchQuery);
        Task<List<Episode>> GetEpisodesAsync(int showId);
    }
}
