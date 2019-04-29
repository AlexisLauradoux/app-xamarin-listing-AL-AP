using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.ViewModels;

namespace app_xamarin_listing_AL_AP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class ListingDetailPage : ContentPage
    {
        private ListingDetailViewModel viewModel;

        public ListingDetailPage(ListingDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ListingDetailPage()
        {
            InitializeComponent();

            viewModel = new ListingDetailViewModel(null);

            BindingContext = viewModel;
        }
    }
}