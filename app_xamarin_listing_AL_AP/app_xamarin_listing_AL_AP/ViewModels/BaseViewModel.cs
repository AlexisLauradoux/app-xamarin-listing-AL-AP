using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using app_xamarin_listing_AL_AP.Models;
using app_xamarin_listing_AL_AP.DAL;
using app_xamarin_listing_AL_AP.Services;

namespace app_xamarin_listing_AL_AP.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Listing> ListingDataStore => DependencyService.Get<IDataStore<Listing>>() ?? new ListingDataStore();
        public IDataStore<Category> CategoryDataStore => DependencyService.Get<IDataStore<Category>>() ?? new CategoryDataStore();
        internal ApiWebService ApiWebService => DependencyService.Get<ApiWebService>() ?? new ApiWebService();

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}