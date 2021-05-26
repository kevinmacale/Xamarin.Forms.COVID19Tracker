using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Shared.Model
{
    public class ClosedCases : ObservableObject
    {
        private int _total;
        private int _recovered;
        private int _deaths;

        public int Total { get => _total; set => SetProperty(ref _total, value); }
        public int Recovered { get => _recovered; set => SetProperty(ref _recovered, value); }
        public int Deaths { get => _deaths; set => SetProperty(ref _deaths, value); }
    }
}
