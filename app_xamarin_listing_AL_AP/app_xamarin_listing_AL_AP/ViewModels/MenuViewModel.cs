using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Utilities;
using app_xamarin_listing_AL_AP.Views;
using Xamarin.Forms;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private List<HomeMenuItem> menuItems = null;

        private MainPage rootPage { get => Application.Current.MainPage as MainPage; }

        public Command LoginLogoutCommand { get; set; }

        public List<HomeMenuItem> MenuItems
        {
            get { return menuItems; }
            set { SetProperty(ref menuItems, value); }
        }

        public MainPage RootPage
        {
            get { return rootPage; }
        }

        private string loginLogoutButtonText;

        public string LoginLogoutButtonText
        {
            get { return loginLogoutButtonText; }
            set { SetProperty(ref loginLogoutButtonText, value); }
        }

        private async Task<bool> ExecuteLoginLogoutCommand()
        {
            if (IsBusy)
                return false;

            IsBusy = true;
            if (Settings.IsConnected)
            {
                Settings.IsConnected = false;
                MessagingCenter.Send<MenuViewModel>(this, "IsConnected");
            }
            else
            {
                await RootPage.NavigateFromMenu((int)MenuItemType.Login);
            }
            IsBusy = false;

            return false;
        }

        private void UpdateButton()
        {
            if (Settings.IsConnected)
            {
                LoginLogoutButtonText = Ressources.AppResources.LogoutButton;
            }
            else
            {
                LoginLogoutButtonText = Ressources.AppResources.LoginButton;
            }
        }

        public MenuViewModel()
        {
            MessagingCenter.Subscribe<MenuViewModel>(this, "IsConnected", (MenuViewModel) => { UpdateButton(); });
            MenuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Listings, Title="Listings" },
                new HomeMenuItem {Id = MenuItemType.NewListing, Title="New listing" },
            };
            LoginLogoutCommand = new Command(async () => await ExecuteLoginLogoutCommand());

            UpdateButton();
        }
    }
}