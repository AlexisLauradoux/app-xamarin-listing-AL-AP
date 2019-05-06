using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Views;
using System.Collections.Generic;
using app_xamarin_listing_AL_AP.Utilities;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class MessageSentViewModel : BaseViewModel
    {
        private ObservableCollection<Message> messages = null;

        public ObservableCollection<Message> Messages
        {
            get { return messages; }
            set { SetProperty(ref messages, value); }
        }

        public Command LoadItemsCommand { get; set; }

        public MessageSentViewModel()
        {
            Title = Ressources.AppResources.MessageSent;
            Messages = new ObservableCollection<Message>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Messages.Clear();
                List<Message> var = await ApiWebService.GetMessageSentAsync();
                if (var == null)
                {
                    IsBusy = false;
                    Dictionary<string, string> TrackEvent = new Dictionary<string, string>();

                    TrackEvent.Add("Error get messages", "");

                    TrackEvent.Add("User", Settings.Email);

                    Insights.TrackEvent("SentMessage", TrackEvent);

                    await Application.Current.MainPage.DisplayAlert(Ressources.AppResources.Error, Ressources.AppResources.NoConnection, Ressources.AppResources.Ok);
                    return;
                }
                foreach (var item in var)
                {
                    Messages.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Insights.ReportError(ex, null);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}