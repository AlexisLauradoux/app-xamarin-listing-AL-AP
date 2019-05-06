using System;
using System.Collections.Generic;
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

                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("Error send messages", message.Content);
                keyValuePairs.Add("Annonce id", message.IdAnnonce);
                keyValuePairs.Add("User", Settings.Email);

                Insights.TrackEvent("SendMessage", keyValuePairs);
                await Application.Current.MainPage.DisplayAlert(Ressources.AppResources.Error, Ressources.AppResources.ErrorMessage, Ressources.AppResources.Ok);
                return false;
            }

            IsBusy = false;

            Dictionary<string, string> TrackEvent = new Dictionary<string, string>();

            TrackEvent.Add("Send messages", message.Content);
            TrackEvent.Add("Annonce id", message.IdAnnonce);
            TrackEvent.Add("User", Settings.Email);

            Insights.TrackEvent("SendMessage", TrackEvent);
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