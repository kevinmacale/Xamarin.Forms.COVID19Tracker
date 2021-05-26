using COVID19.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Server.Proxy
{
    public class COVID19Proxy : BaseRestProxy
    {
        public COVID19Proxy(string baseURL) : base(baseURL)
        {
        }

        public async Task<COVID19CaseSummary> GetCOVID19CaseSummarysAsync()
        {
            var response = await GetAsync<COVID19CaseSummary>("api/v1/cases").ConfigureAwait(false);
            return response;
        }

        public async Task<StatisticSummary> GetGlobalStatisticSummaryAsync()
        {
            var response = await GetAsync<StatisticSummary>("api/v1/world").ConfigureAwait(false);
            return response;
        }
        public async Task<StatisticSummary> GetContinentStatisticSummaryByContinentNameAsync(string continent)
        {
            var response = await GetAsync<StatisticSummary>($"api/v1/world/continent/{continent}").ConfigureAwait(false);
            return response;
        }

        public async Task<StatisticSummary> GetCountryStatisticSummaryAsync(string country)
        {
            var response = await GetAsync<StatisticSummary>($"api/v1/world/country/{country}").ConfigureAwait(false);
            return response;
        }
    }
}
