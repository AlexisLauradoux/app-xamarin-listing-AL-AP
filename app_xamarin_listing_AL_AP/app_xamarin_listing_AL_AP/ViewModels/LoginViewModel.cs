using System;
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

        private string email = null;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string password = null;

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

            Settings.Login = Email;
            Settings.Password = Password;

            string response = await ApiWebService.Authentification();

            if (response == null)
            {
                return false;
            }

            if (response == string.Empty)
            {
                return false;
            }

            IsBusy = false;

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