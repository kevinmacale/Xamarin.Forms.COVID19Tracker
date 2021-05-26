using COVID19.Client.Services;
using COVID19.Server.Proxy;
using COVID19.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Client.Store
{
    public class COVIDDataStore
    {
        public EventHandler COVIDDataStoreHandler;
        public COVID19CaseSummary CaseSummary { get; internal set; }
        public ICOVID19ProxyService COVID19Proxy { get => ServiceLocator.Instance.Get<ICOVID19ProxyService>(); }

        public async Task GetCaseSummary()
        {
            if (COVID19Proxy == null)
                return;

            try
            {
                CaseSummary = await COVID19Proxy.GetCOVID19CaseSummarysAsync().ConfigureAwait(false);
                COVIDDataStoreHandler?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // TODO: Handles Error Logs
            }
        }
    }
}
