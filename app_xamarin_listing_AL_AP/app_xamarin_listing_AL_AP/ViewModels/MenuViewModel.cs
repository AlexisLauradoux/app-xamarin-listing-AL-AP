using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Services;
using app_xamarin_listing_AL_AP.Utilities;
using app_xamarin_listing_AL_AP.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        private string email;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
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
                MenuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Listings, Title=Ressources.AppResources.Listings },
                new HomeMenuItem {Id = MenuItemType.NewListing, Title=Ressources.AppResources.NewListing },
                new HomeMenuItem {Id = MenuItemType.MessageReceive, Title=Ressources.AppResources.MessageReceive },
                new HomeMenuItem {Id = MenuItemType.MessageSent, Title=Ressources.AppResources.MessageSent },
            };
                Email = Settings.Email;
            }
            else
            {
                LoginLogoutButtonText = Ressources.AppResources.LoginButton;
                MenuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Listings, Title=Ressources.AppResources.Listings },
            };
                Email = "";
            }
        }

        public MenuViewModel()
        {
            MessagingCenter.Subscribe<ApiWebService>(this, "IsConnected", (MenuViewModel) => { UpdateButton(); });
            MessagingCenter.Subscribe<MenuViewModel>(this, "IsConnected", (MenuViewModel) => { UpdateButton(); });
            LoginLogoutCommand = new Command(async () => await ExecuteLoginLogoutCommand());

            UpdateButton();
        }

        ~MenuViewModel()
        {
            MessagingCenter.Unsubscribe<ApiWebService>(this, "IsConnected");
            MessagingCenter.Unsubscribe<MenuViewModel>(this, "IsConnected");
        }
    }
}