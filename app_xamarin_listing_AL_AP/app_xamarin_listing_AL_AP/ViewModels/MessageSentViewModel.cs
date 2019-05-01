using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Views;

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
                foreach (var item in await ApiWebService.GetMessageSentAsync())
                {
                    Messages.Add(item);
                }
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
    }
}