using System;
using System.Threading.Tasks;
using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Utilities;
using app_xamarin_listing_AL_AP.Views;
using Xamarin.Forms;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class SendMessageViewModel : BaseViewModel
    {
        public Command SendMessageCommand { get; set; }

        private SendMessagePage sendMessagePage;

        private Message message = null;

        public Message Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private async Task<bool> ExecuteSendMessageCommand()
        {
            if (IsBusy)
                return false;

            IsBusy = true;

            bool response = await ApiWebService.SendMessageAsync(Message);

            if (!response)
            {
                IsBusy = false;
                return false;
            }

            IsBusy = false;

            await sendMessagePage.Navigation.PopAsync();

            return true;
        }

        public SendMessageViewModel(SendMessagePage sendMessagePage, Listing listing)
        {
            this.sendMessagePage = sendMessagePage;
            Message = new Message();
            Message.IdAnnonce = listing.Id;
            Title = Ressources.AppResources.SendMessage;
            SendMessageCommand = new Command(async () => await ExecuteSendMessageCommand());
        }
    }
}