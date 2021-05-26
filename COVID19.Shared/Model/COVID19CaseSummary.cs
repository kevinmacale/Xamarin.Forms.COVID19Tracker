using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Shared.Model
{
    public class COVID19CaseSummary : ObservableObject
    {
        private string _timeStamp;
        private string _total;
        private ClosedCases _closedCases;
        private ActiveCases _activeCases;
        private COVID19Graphs _graphs;

        public string TimeStamp { get => _timeStamp; set => SetProperty(ref _timeStamp, value); }
        public string Total { get => _total; set => SetProperty(ref _total, value); }
        public ClosedCases ClosedCases { get => _closedCases; set => SetProperty(ref _closedCases, value); }
        public ActiveCases ActiveCases { get => _activeCases; set => SetProperty(ref _activeCases, value); }
        public COVID19Graphs Graphs { get => _graphs; set => SetProperty(ref _graphs, value); }
    }
}
