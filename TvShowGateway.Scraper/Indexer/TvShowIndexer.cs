using System.Linq;
using System.Threading.Tasks;
using TvShowGateway.Scraper.Client;
using TvShowGateway.Scraper.Model;
using TvShowGateway.Service.Episode;
using TvShowGateway.Service.TvShow;

namespace TvShowGateway.Scraper.Indexer
{
    public class TvShowIndexer: ITvShowIndexer
    {
        private readonly ITvShowScraper _tvShowService;
        private readonly IEpisodeScraper _episodeService;
        private readonly ITvMazeClient _tvMazeClient;

        public TvShowIndexer(ITvShowScraper tvShowService, IEpisodeScraper episodeService, ITvMazeClient tvMazeClient)
        {
            _tvShowService = tvShowService;
            _episodeService = episodeService;
            _tvMazeClient = tvMazeClient;
        }

        public async Task IndexTvShowsWithEpisodesAsync(string searchTerm)
        {
            var shows = await _tvMazeClient.GetShowsAsync(searchTerm);
            var showIndexTasks = shows.Select(IndexShowAsync).ToList();
            await Task.WhenAll(showIndexTasks);
        }

        private async Task IndexShowAsync(ShowSearchResult show)
        {
            if (!await _tvShowService.TvShowExistsAsync(show.Show.Name))
            {
                var tvShowModel = new TvShowModel()
                {
                    TvShowId = show.Show.Id,
                    Name = show.Show.Name,
                    Summary = show.Show.Summary
                };

                await _tvShowService.AddTvShowAsync(tvShowModel);
            }

            var episodes = await _tvMazeClient.GetEpisodesAsync(show.Show.Id);
            var episodeTasks = episodes.Select(episode => IndexEpisodeAsync(show.Show.Id, episode)).ToList();

            await Task.WhenAll(episodeTasks);
        }

        private async Task IndexEpisodeAsync(int showId, Episode episode)
        {
            if (!await _episodeService.EpisodeExistsAsync(showId, episode.Season, episode.Number))
            {
                var episodeModel = new EpisodeModel()
                {
                    TvShowId = showId,
                    SeasonNumber = episode.Season,
                    EpisodeNumber = episode.Number,
                    Summary = episode.Summary
                };

                await _episodeService.InsertEpisodeAsync(showId, episodeModel);
            }
        }
    }
}
