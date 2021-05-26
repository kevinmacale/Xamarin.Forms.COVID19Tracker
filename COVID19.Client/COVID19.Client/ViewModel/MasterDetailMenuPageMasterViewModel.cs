using COVID19.Client.View;
using COVID19.Client.View.MasterDetail;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace COVID19.Client.ViewModel
{
    public class MasterDetailMenuPageMasterViewModel : BaseViewModel
    {
        private Type _previousType = typeof(MainPage);
        private readonly Dictionary<Type, Page> _pageCache = new Dictionary<Type, Page>();
        private ObservableCollection<MasterDetailMenuPageMasterMenuItem> _menuItems;
        public ObservableCollection<MasterDetailMenuPageMasterMenuItem> MenuItems { get => _menuItems; set => SetProperty(ref _menuItems, value); }
        public ICommand MenuSelectionCommand { get; set; }
        public MasterDetailMenuPageMasterViewModel()
        {
            Title = "COVID-19 Tracker";
            MenuSelectionCommand = new Command(DoMenuSelection);
            LoadMenuItems();
        }

        private void DoMenuSelection(object obj)
        {
            if (obj == null) return;

            if (obj is MasterDetailMenuPageMasterMenuItem item)
            {
                if (_previousType.Equals(item.TargetType))
                    return;
                else
                    _previousType = item.TargetType;

                if (_pageCache.TryGetValue(item.TargetType, out Page page))
                {
                    var nav = new NavigationPage(page);
                    nav.BarBackgroundColor = (Color)Application.Current.Resources["MainBackgroundColor"];
                    (Application.Current.MainPage as MasterDetailPage).Detail = nav;
                }
                else
                {
                    var newPage = (Page)Activator.CreateInstance(item.TargetType);
                    newPage.Title = item.Title;
                    var nav = new NavigationPage(newPage);
                    nav.BarBackgroundColor = (Color)Application.Current.Resources["MainBackgroundColor"];
                    (Application.Current.MainPage as MasterDetailPage).Detail = nav;
                    _pageCache.Add(item.TargetType, newPage);
                }

                (Application.Current.MainPage as MasterDetailPage).IsPresented = false;
            }
        }

        private void LoadMenuItems()
        {
            MenuItems = new ObservableCollection<MasterDetailMenuPageMasterMenuItem>()
            {
                new MasterDetailMenuPageMasterMenuItem()
                {
                    Id = 0,
                    TargetType = typeof(MainPage),
                    Title = "COVID-19 Case Information"
                },
                new MasterDetailMenuPageMasterMenuItem()
                {
                    Id = 1,
                    TargetType = typeof(COVID19CaseCharts),
                    Title = "COVID-19 Case Analytics"
                },
            };
        }
    }
}
