using System;
using System.Collections.Generic;
using System.Text;

namespace TvShowGateway.Scraper.Model
{
    public class ShowSearchResult
    {
        public double Score { get; set; }
        public TvShow Show { get; set; }
    }
}
