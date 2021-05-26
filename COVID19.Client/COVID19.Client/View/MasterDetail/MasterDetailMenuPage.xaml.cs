using COVID19.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COVID19.Client.View.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailMenuPage : MasterDetailPage
    {

        public MasterDetailMenuPage()
        {
            InitializeComponent();
            var mainpage = new MainPage();
            var nav = new NavigationPage(mainpage);
            nav.BarBackgroundColor = (Color)Application.Current.Resources["MainBackgroundColor"];
            Detail = nav;
        }

        private void CollectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected override void OnAppearing()
        {

        }
    }
}