using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TvShowGateway.Data;

namespace TvShowGateway.Service.TvShow
{
    public class TvShowService: ITvShowGatherer, ITvShowScraper
    {
        private readonly TvShowDbContext _context;

        public TvShowService(TvShowDbContext context)
        {
            _context = context;
        }

        public Task<List<TvShowModel>> SearchForTvShowAsync(string partialShowName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TvShowExistsAsync(string title)
        {
            throw new NotImplementedException();
        }

        public Task AddTvShowAsync(TvShowModel tvShow)
        {
            throw new NotImplementedException();
        }
    }
}
