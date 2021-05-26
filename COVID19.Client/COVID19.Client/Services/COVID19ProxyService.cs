using COVID19.Server.Proxy;
using COVID19.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Client.Services
{
    /// <summary>
    /// Service to call when getiing data from the api
    /// </summary>
    public class COVID19ProxyService : ICOVID19ProxyService
    {
        private readonly COVID19Proxy _covidProxy;

        /// <summary>
        /// Set the _proxy service
        /// </summary>
        /// <param name="proxy"></param>
        public COVID19ProxyService(COVID19Proxy proxy)
        {
            _covidProxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }

        /// <summary>
        /// Get all the cases
        /// </summary>
        /// <returns></returns>
        public async Task<COVID19CaseSummary> GetCOVID19CaseSummarysAsync()
        {
            var statisticSummary = await _covidProxy.GetCOVID19CaseSummarysAsync().ConfigureAwait(false);
            return statisticSummary;
        }
        /// <summary>
        /// Get global statistic summary
        /// </summary>
        /// <returns></returns>
        public async Task<StatisticSummary> GetGlobalStatisticSummaryAsync()
        {
            var statisticSummary = await _covidProxy.GetGlobalStatisticSummaryAsync().ConfigureAwait(false);
            return statisticSummary;
        }
        /// <summary>
        /// Get continental summary
        /// </summary>
        /// <param name="continent"></param>
        /// <returns></returns>
        public async Task<StatisticSummary> GetContinentStatisticSummaryByContinentNameAsync(string continent)
        {
            var statisticSummary = await _covidProxy.GetContinentStatisticSummaryByContinentNameAsync(continent).ConfigureAwait(false);
            return statisticSummary;
        }
        /// <summary>
        /// Get statistic per country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public async Task<StatisticSummary> GetCountryStatisticSummaryAsync(string country)
        {
            var statisticSummary = await _covidProxy.GetCountryStatisticSummaryAsync(country).ConfigureAwait(false);
            return statisticSummary;
        }
    }
}
