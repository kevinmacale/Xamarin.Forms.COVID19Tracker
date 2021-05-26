using COVID19.Client.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Client.ViewModel
{
    public class COVID19CaseChartsViewModel : BaseViewModel
    {
        private ObservableCollection<GraphSelectionModel> _graphSelectionModels;

        public COVID19CaseChartsViewModel()
        {
            Title = "COVID-19 Case Analytics";
        }
        public ObservableCollection<GraphSelectionModel> GraphSelectionModels { get => _graphSelectionModels; set => SetProperty(ref _graphSelectionModels, value); }

        public override async Task OnUnLoaded(object param)
        {
        }

        public override async Task OnLoaded(object param)
        {
            try
            {
                IsProgressing = true;
                LoadPickerSelection();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsProgressing = false;
            }
        }

        private void LoadPickerSelection()
        {
            GraphSelectionModels = new ObservableCollection<GraphSelectionModel>()
            {
                new GraphSelectionModel(){ CaseType = "Total Cases" },
                new GraphSelectionModel(){ CaseType = "Active Cases" },
                new GraphSelectionModel(){ CaseType = "Daily Cases" },
            };
        }

    }
}
