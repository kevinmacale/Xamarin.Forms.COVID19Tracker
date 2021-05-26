using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Shared.Model
{
    public class COVID19GrahpModel : ObservableObject
    {
        private string _title;
        private string _details;
        private List<int?> _data;
        private List<string> _categories;
        private string _xLabel;
        private string _yLabel;
        private string _source;
        private string _sourceLink;

        public string Title { get => _title; set => SetProperty(ref _title, value); }
        public string Details { get => _details; set => SetProperty(ref _details, value); }
        public List<int?> Data { get => _data; set => SetProperty(ref _data, value); }
        public List<string> Categories { get => _categories; set => SetProperty(ref _categories, value); }
        public string XLabel { get => _xLabel; set => SetProperty(ref _xLabel, value); }
        public string YLabel { get => _yLabel; set => SetProperty(ref _yLabel, value); }
        public string Source { get => _source; set => SetProperty(ref _source, value); }
        public string SourceLink { get => _sourceLink; set => SetProperty(ref _sourceLink, value); }
    }
}
