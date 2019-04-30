using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.Views;
using app_xamarin_listing_AL_AP.ViewModels;

namespace app_xamarin_listing_AL_AP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class ListingsPage : ContentPage
    {
        private ListingsViewModel viewModel;

        public ListingsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListingsViewModel();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Listing;
            if (item == null)
                return;

            await Navigation.PushAsync(new ListingDetailPage(new ListingDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Listings.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}