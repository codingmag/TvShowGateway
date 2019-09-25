using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TvShowGateway.Scraper.Client;
using TvShowGateway.Scraper.Indexer;
using TvShowGateway.Service.Episode;
using TvShowGateway.Service.TvShow;

namespace TvShowGateway.Scraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0 || string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Please provide a search term as an argument!");
            }

            var searchTerm = args[0];

            var collection = new ServiceCollection();
            collection.AddHttpClient("TvMaze", x => { x.BaseAddress = new Uri(TvMazeConstants.BaseUrl); });
            collection.AddSingleton<ITvMazeClient, TvMazeClient>();
            collection.AddTransient<ITvShowScraper, TvShowService>();
            collection.AddTransient<IEpisodeScraper, EpisodeService>();
            collection.AddTransient<ITvShowIndexer, TvShowIndexer>();

            var serviceProvider = collection.BuildServiceProvider();
            var indexer = serviceProvider.GetService<ITvShowIndexer>();
            await indexer.IndexTvShowsWithEpisodesAsync(searchTerm);
        }
    }
}
