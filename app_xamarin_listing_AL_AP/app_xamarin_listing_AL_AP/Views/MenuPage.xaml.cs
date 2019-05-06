using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_xamarin_listing_AL_AP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MenuPage : ContentPage
    {
        private MenuViewModel viewModel;

        public MenuPage()
        {
            InitializeComponent();

            viewModel = new MenuViewModel();

            BindingContext = viewModel;

            ListViewMenu.SelectedItem = viewModel.MenuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await viewModel.RootPage.NavigateFromMenu(id);
            };
        }
    }
}