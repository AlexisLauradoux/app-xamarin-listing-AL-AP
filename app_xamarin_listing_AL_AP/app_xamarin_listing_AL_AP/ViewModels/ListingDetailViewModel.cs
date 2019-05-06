using System;
using System.Diagnostics;
using System.Threading.Tasks;
using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Services;
using app_xamarin_listing_AL_AP.Utilities;
using app_xamarin_listing_AL_AP.Views;
using Xamarin.Forms;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class ListingDetailViewModel : BaseViewModel
    {
        private Listing listing;

        private bool activeSendButton;

        private ListingDetailPage listingDetailPage;

        public Command SendMessageCommand { get; set; }

        private async Task ExecuteSendMessageCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await listingDetailPage.Navigation.PushAsync(new SendMessagePage(Listing));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Listing Listing
        {
            get { return listing; }
            set { SetProperty(ref listing, value); }
        }

        public bool ActiveSendButton
        {
            get { return activeSendButton; }
            set { SetProperty(ref activeSendButton, value); }
        }

        public ListingDetailViewModel(Listing listing, ListingDetailPage listingDetailPage)
        {
            Title = Ressources.AppResources.ListingDetails;
            this.listingDetailPage = listingDetailPage;
            Listing = listing;
            SendMessageCommand = new Command(async () => await ExecuteSendMessageCommand());
            ActiveSendButton = Settings.IsConnected;
            MessagingCenter.Subscribe<ApiWebService>(this, "IsConnected", (MenuViewModel) => { ActiveSendButton = Settings.IsConnected; });
            MessagingCenter.Subscribe<MenuViewModel>(this, "IsConnected", (MenuViewModel) => { ActiveSendButton = Settings.IsConnected; });
        }

        ~ListingDetailViewModel()
        {
            MessagingCenter.Unsubscribe<ApiWebService>(this, "IsConnected");
            MessagingCenter.Unsubscribe<MenuViewModel>(this, "IsConnected");
        }
    }
}