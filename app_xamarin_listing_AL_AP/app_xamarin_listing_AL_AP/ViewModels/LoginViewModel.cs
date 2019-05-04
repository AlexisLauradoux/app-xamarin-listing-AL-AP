using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Utilities;
using app_xamarin_listing_AL_AP.Views;
using Xamarin.Forms;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; set; }

        private MainPage mainPage;

        private string email = Settings.Email;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string password = Settings.Password;

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private async Task<bool> ExecuteLoginCommand()
        {
            if (IsBusy)
                return false;

            IsBusy = true;

            Settings.Email = Email;
            Settings.Password = Password;

            string response = await ApiWebService.Authentification();

            if (response == null)
            {
                IsBusy = false;

                Dictionary<string, string> TrackEvent = new Dictionary<string, string>();

                TrackEvent.Add("Connected", "No connection");

                TrackEvent.Add("User", Settings.Email);

                Insights.TrackEvent("User", TrackEvent);

                await mainPage.DisplayAlert(Ressources.AppResources.Error, Ressources.AppResources.NoConnection, Ressources.AppResources.Ok);
                return false;
            }

            if (response == string.Empty)
            {
                IsBusy = false;

                Dictionary<string, string> TrackEvent = new Dictionary<string, string>();

                TrackEvent.Add("Connected", "false");

                TrackEvent.Add("User", Settings.Email);

                Insights.TrackEvent("User", TrackEvent);

                await mainPage.DisplayAlert(Ressources.AppResources.Error, Ressources.AppResources.UserNoReconize, Ressources.AppResources.Ok);
                return false;
            }

            IsBusy = false;

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            keyValuePairs.Add("Connected", "true");

            keyValuePairs.Add("User", Settings.Email);

            Insights.TrackEvent("User", keyValuePairs);

            await mainPage.NavigateFromMenu((int)MenuItemType.Listings);

            return true;
        }

        public LoginViewModel(MainPage mainPage)
        {
            this.mainPage = mainPage;
            Title = Ressources.AppResources.LoginTitle;
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }
    }
}