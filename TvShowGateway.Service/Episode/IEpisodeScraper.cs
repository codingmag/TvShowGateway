using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TvShowGateway.Service.Episode
{
    public interface IEpisodeScraper
    {
        /// <summary>
        /// Checks if the episodes of given TV show exist in our DB
        /// </summary>
        Task<bool> EpisodeExistsAsync(int tvShowId, int seasonNumber, int episodeNumber);

        Task InsertEpisodeAsync(int tvShowId, EpisodeModel episode);
    }
}
