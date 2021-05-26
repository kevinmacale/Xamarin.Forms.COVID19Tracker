namespace COVID19.Shared.Model
{
    public class COVID19Graphs : ObservableObject
    {
        private COVID19GrahpModel _totalCases;
        private COVID19GrahpModel _activeCases;
        private COVID19GrahpModel _dailyCases;

        public COVID19GrahpModel TotalCases { get => _totalCases; set => SetProperty(ref _totalCases, value); }
        public COVID19GrahpModel ActiveCases { get => _activeCases; set => SetProperty(ref _activeCases, value); }
        public COVID19GrahpModel DailyCases { get => _dailyCases; set => SetProperty(ref _dailyCases, value); }
    }
}