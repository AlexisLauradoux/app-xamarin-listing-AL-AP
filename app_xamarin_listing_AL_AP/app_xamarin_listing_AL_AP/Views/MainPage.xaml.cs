using app_xamarin_listing_AL_AP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_xamarin_listing_AL_AP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : MasterDetailPage
    {
        private Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Listings, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Listings:
                        MenuPages.Add(id, new NavigationPage(new ListingsPage(this)));
                        break;

                    case (int)MenuItemType.NewListing:
                        MenuPages.Add(id, new NavigationPage(new NewListingPage(this)));
                        break;

                    case (int)MenuItemType.Login:
                        MenuPages.Add(id, new NavigationPage(new LoginPage(this)));
                        break;

                    case (int)MenuItemType.MessageReceive:
                        MenuPages.Add(id, new NavigationPage(new MessageReceivePage()));
                        break;

                    case (int)MenuItemType.MessageSent:
                        MenuPages.Add(id, new NavigationPage(new MessageSentPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}