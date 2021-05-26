using COVID19.Server.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var covidProxy = new COVID19Proxy("https://covid19-update-api.herokuapp.com/");
            var caseSummary = await covidProxy.GetCOVID19CaseSummarysAsync().ConfigureAwait(false);
            var globalStats = await covidProxy.GetGlobalStatisticSummaryAsync().ConfigureAwait(false);
            var asiaStats = await covidProxy.GetContinentStatisticSummaryByContinentNameAsync("Asia").ConfigureAwait(false);
            var phStats = await covidProxy.GetCountryStatisticSummaryAsync("Philippines").ConfigureAwait(false);

            System.Console.Read();
        }
    }
}
