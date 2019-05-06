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
        public ListingDetailPage(Listing listing)
        {
            InitializeComponent();

            BindingContext = new ListingDetailViewModel(listing, this);
        }
    }
}