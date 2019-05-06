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
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel viewModel;

        public LoginPage(MainPage mainPage)
        {
            InitializeComponent();

            viewModel = new LoginViewModel(mainPage);

            BindingContext = viewModel;
        }
    }
}