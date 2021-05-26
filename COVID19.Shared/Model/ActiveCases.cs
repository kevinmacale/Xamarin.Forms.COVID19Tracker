namespace COVID19.Shared.Model
{
    public class ActiveCases : ObservableObject
    {
        private int _total;
        private int _mild;
        private int _critical;

        public int Total { get => _total; set => SetProperty(ref _total, value); }
        public int Mild { get => _mild; set => SetProperty(ref _mild, value); }
        public int Critical { get => _critical; set => SetProperty(ref _critical, value); }
    }
}