using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TvShowGateway.Data;

namespace TvShowGateway.Service.Episode
{
    public class EpisodeService: IEpisodeGatherer, IEpisodeScraper
    {
        private readonly TvShowDbContext _context;

        public EpisodeService(TvShowDbContext context)
        {
            _context = context;
        }

        public async Task<List<EpisodeModel>> GetAllEpisodesAsync(int tvShowId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EpisodeExistsAsync(int tvShowId, int seasonNumber, int episodeNumber)
        {
            throw new NotImplementedException();
        }

        public async Task InsertEpisodeAsync(int tvShowId, EpisodeModel episode)
        {
            throw new NotImplementedException();
        }
    }
}
