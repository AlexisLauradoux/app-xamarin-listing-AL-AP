using app_xamarin_listing_AL_AP.Models;
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
    public partial class SendMessagePage : ContentPage
    {
        private SendMessageViewModel viewModel;

        public SendMessagePage(Listing listing)
        {
            InitializeComponent();

            viewModel = new SendMessageViewModel(this, listing);

            BindingContext = viewModel;
        }
    }
}