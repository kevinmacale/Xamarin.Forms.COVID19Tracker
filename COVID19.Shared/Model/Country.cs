using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Shared.Model
{
    public class Country : ObservableObject
    {
        private string _name;
        private int _cases;
        private int _deaths;
        private string _continent;

        public string Name { get => _name; set => SetProperty(ref _name, value); }
        public int Cases { get => _cases; set => SetProperty(ref _cases, value); }
        public int Deaths { get => _deaths; set => SetProperty(ref _deaths, value); }
        public string Continent { get => _continent; set => SetProperty(ref _continent, value); }
    }
}
