using COVID19.Shared.Model;
using System.Threading.Tasks;

namespace COVID19.Client.Services
{
    public interface ICOVID19ProxyService
    {
        Task<StatisticSummary> GetContinentStatisticSummaryByContinentNameAsync(string continent);
        Task<StatisticSummary> GetCountryStatisticSummaryAsync(string country);
        Task<COVID19CaseSummary> GetCOVID19CaseSummarysAsync();
        Task<StatisticSummary> GetGlobalStatisticSummaryAsync();
    }
}