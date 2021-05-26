using COVID19.Client.Store;
using Matcha.BackgroundService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Client.Services.BackgroundService
{
    public class PeriodCall : IPeriodicTask
    {
        public PeriodCall(int seconds)
        {
            Interval = TimeSpan.FromSeconds(seconds);
        }

        public TimeSpan Interval { get; set; }

        public async Task<bool> StartJob()
        {
            // Trigger the synch event
            await ServiceLocator.Instance.Get<COVIDDataStore>().GetCaseSummary().ConfigureAwait(false);
            return true;
        }
    }
}
