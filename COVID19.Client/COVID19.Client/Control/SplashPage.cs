using COVID19.Client.Services;
using COVID19.Client.Services.BackgroundService;
using COVID19.Client.Store;
using COVID19.Client.View.MasterDetail;
using Matcha.BackgroundService;
using PCLAppConfig;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace COVID19.Client.Control
{
    /// <summary>
    /// Handles the splash screen page
    /// </summary>
    public class SplashPage : ContentPage
    {
        /// <summary>
        /// Holds the image for splash screen
        /// </summary>
        public StackLayout Stack { get; set; }
        public Image SplashImage { get; }

        public SplashPage()
        {
            var sub = new AbsoluteLayout()
            {
                BackgroundColor = (Color)Application.Current.Resources["MainBackgroundColor"]
            };
            Stack = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };
            SplashImage = new Image
            {
                Source = "VirusLogo.png",
                WidthRequest = 150,
                HeightRequest = 150,
            };
            var titleLabel = new Label()
            {
                Text = "COVID-19 TRACKER",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Stack.Children.Add(SplashImage);
            Stack.Children.Add(titleLabel);
            AbsoluteLayout.SetLayoutFlags(Stack, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(Stack, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            sub.Children.Add(Stack);
            Content = sub;
        }

        /// <summary>
        /// Handles on appearing event
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var covidProxy = new COVID19ProxyService(new Server.Proxy.COVID19Proxy(ConfigurationManager.AppSettings.Get("BaseAPIAddress")));
            var covidDataStore = new COVIDDataStore();
            var interval = ConfigurationManager.AppSettings.Get("Interval");

            ServiceLocator.Instance.Register<ICOVID19ProxyService>(covidProxy);
            ServiceLocator.Instance.Register(covidDataStore);
            BackgroundAggregatorService.Add(() => new PeriodCall(int.Parse(interval)));
            BackgroundAggregatorService.StartBackgroundService();

            await SplashImage.RotateTo(360, 3000);
            await Stack.ScaleTo(1, 1000); // Time consuming process such as initialization
            await Stack.ScaleTo(0.9, 800, Easing.Linear);
            await Stack.FadeTo(0.5, 700);
            await Stack.ScaleTo(50, 100, Easing.Linear);
            await Stack.FadeTo(0, 100);
            Application.Current.MainPage = new MasterDetailMenuPage();
        }
    }
}
