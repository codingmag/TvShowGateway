using System.Collections.Generic;
using System.Threading.Tasks;

namespace TvShowGateway.Service.TvShow
{
    public interface ITvShowGatherer
    {
        /// <summary>
        /// Searches for the TV show by trying to match the given partial name
        /// </summary>
        Task<List<TvShowModel>> SearchForTvShowAsync(string partialShowName);
    }
}
