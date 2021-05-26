using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Shared.Model
{
    public class StatisticSummary : ObservableObject
    {
        private string _timeStamp;
        private int _total;
        private List<Country> _countries;

        public string TimeStamp { get => _timeStamp; set => SetProperty(ref _timeStamp, value); }
        public int Total { get => _total; set => SetProperty(ref _total, value); }
        public List<Country> Countries { get => _countries; set => SetProperty(ref _countries, value); }
    }
}
