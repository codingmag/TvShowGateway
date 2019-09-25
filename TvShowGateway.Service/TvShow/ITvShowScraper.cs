using System.Threading.Tasks;

namespace TvShowGateway.Service.TvShow
{
    public interface ITvShowScraper
    {
        /// <summary>
        /// Checks if the TV show with title exists in our DB
        /// </summary>
        Task<bool> TvShowExistsAsync(string title);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tvShow"></param>
        Task AddTvShowAsync(TvShowModel tvShow);
    }
}
