using app_xamarin_listing_AL_AP.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_xamarin_listing_AL_AP.Views
{
    [DesignTimeVisible(true)]
    public partial class MessageSentPage : ContentPage
    {
        private MessageSentViewModel viewModel;

        public MessageSentPage()
        {
            InitializeComponent();

            viewModel = new MessageSentViewModel();

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Messages.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}