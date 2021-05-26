using COVID19.Client.Services;
using COVID19.Client.Store;
using COVID19.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Client.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private COVID19CaseSummary _covidCaseSummary;
        public MainViewModel()
        {
            Title = "COVID-19 Case Information";
        }

        public ICOVID19ProxyService COVID19ProxyService { get => Services.Get<ICOVID19ProxyService>(); }
        public COVIDDataStore COVIDDataStore { get => Services.Get<COVIDDataStore>(); }
        public COVID19CaseSummary COVIDCaseSummary { get => _covidCaseSummary; private set => SetProperty(ref _covidCaseSummary, value); }
        public override async Task OnLoaded(object param)
        {
            try
            {
                IsProgressing = true;
                COVIDDataStore.COVIDDataStoreHandler += COVIDDataStoreEventHandler;
                await COVIDDataStore.GetCaseSummary().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                IsProgressing = false;
            }
        }

        public override async Task OnUnLoaded(object param)
        {
            COVIDDataStore.COVIDDataStoreHandler -= COVIDDataStoreEventHandler;
        }

        private void COVIDDataStoreEventHandler(object sender, EventArgs e)
        {
            COVIDCaseSummary = COVIDDataStore.CaseSummary;
        }
    }
}
