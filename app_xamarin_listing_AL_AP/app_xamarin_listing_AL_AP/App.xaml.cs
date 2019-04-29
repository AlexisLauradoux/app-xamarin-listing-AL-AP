using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using app_xamarin_listing_AL_AP.Views;
using app_xamarin_listing_AL_AP.DAL;

namespace app_xamarin_listing_AL_AP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ListingDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}