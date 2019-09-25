using System.Collections.Generic;
using System.Threading.Tasks;

namespace TvShowGateway.Service.Episode
{
    public interface IEpisodeGatherer
    {
        /// <summary>
        /// Gets all episodes of the given TV show
        /// </summary>
        Task<List<EpisodeModel>> GetAllEpisodesAsync(int tvShowId);
    }
}
