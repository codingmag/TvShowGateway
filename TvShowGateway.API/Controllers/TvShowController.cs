using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using TvShowGateway.Service.Episode;
using TvShowGateway.Service.TvShow;

namespace TvShowGateway.API.Controllers
{
    [Route("api/v1/shows")]
    [ApiController]
    public class TvShowController: ControllerBase
    {
        private readonly ITvShowGatherer _tvShowService;
        private readonly IEpisodeGatherer _episodeService;

        public TvShowController(ITvShowGatherer tvShowService, IEpisodeGatherer episodeService)
        {
            _tvShowService = tvShowService;
            _episodeService = episodeService;
        }

        [HttpGet]
        [Route("search/{partialTitle}")]
        public async Task<IActionResult> SearchTvShows(string partialTitle)
        {
            // Todo validate input

            var shows = await _tvShowService.SearchForTvShowAsync(partialTitle);
            if (!shows.Any())
            {
                return NotFound();
            }

            return Ok(shows);
        }

        [HttpGet]
        [Route("{showId}/episodes")]
        public async Task<IActionResult> GetEpisodes(int showId)
        {
            var episodes = await _episodeService.GetAllEpisodesAsync(showId);

            if (!episodes.Any())
            {
                return NotFound();
            }

            return Ok(episodes);
        }
    }
}
