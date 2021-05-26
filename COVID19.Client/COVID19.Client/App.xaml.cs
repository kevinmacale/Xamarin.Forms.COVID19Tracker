using COVID19.Client.Control;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COVID19.Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SplashPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
