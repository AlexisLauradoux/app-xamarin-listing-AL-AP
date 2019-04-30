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
    public partial class NewListingPage : ContentPage
    {
        private NewListingViewModel viewModel;

        public NewListingPage(NewListingViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public NewListingPage()
        {
            InitializeComponent();

            viewModel = new NewListingViewModel();

            BindingContext = viewModel;
        }
    }
}