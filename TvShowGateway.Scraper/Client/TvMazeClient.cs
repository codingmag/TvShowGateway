using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TvShowGateway.Scraper.Model;

namespace TvShowGateway.Scraper.Client
{
    public class TvMazeClient : ITvMazeClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TvMazeClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<List<ShowSearchResult>> GetShowsAsync(string searchQuery)
        {
            var searchUrl = $"{TvMazeConstants.TvShowsUrl}?q={searchQuery}";
            return await GetAsync<List<ShowSearchResult>>(searchUrl);
        }

        public async Task<List<Episode>> GetEpisodesAsync(int showId)
        {
            var episodesUrl = $"{TvMazeConstants.TvShowsUrl}/{showId}/episodes";
            return await GetAsync<List<Episode>>(episodesUrl);
        }

        private async Task<T> GetAsync<T>(string url)
        {
            var httpClient = _httpClientFactory.CreateClient("TvMaze");
            var result = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
